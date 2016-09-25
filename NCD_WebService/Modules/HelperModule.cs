using NCD_EmailSend;
using NCD_Model;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace NCD_WebService
{
    public static class HelperModule
    {
        public const int MaxItemsPerEmail = 10;
        private static Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Validate input data
        /// </summary>
        /// <param name="searchParams"></param>
        /// <param name="maxItems"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        internal static Result ValidateInputData(SearchParams searchParams, int maxItems, string email)
        {
            var result = new Result();
            result.Error = string.Empty;

            if (searchParams == null)
                throw new Exception("SearchParams is null; ");

            if (!EmailSendManager.IsValidEmail(email))
                throw new Exception(String.Format("Email ({0}) is invalid; ", email));

            if (maxItems <= 0)
                throw new Exception(String.Format("Max items ({0}) must be greater than 0 is invalid; ", email));

            //these validate we have to do on front end!
            //it did only for test
            if (searchParams.StartAge.HasValue && searchParams.EndAge.HasValue &&
                    searchParams.StartAge.Value > searchParams.EndAge.Value)
                result.Error += "Start age more than end one; ";

            if (searchParams.StartHeight.HasValue && searchParams.EndHeight.HasValue &&
                    searchParams.StartHeight.Value > searchParams.EndHeight.Value)
                result.Error += "Start height more than end one; ";

            if (searchParams.StartWeight.HasValue && searchParams.EndWeight.HasValue &&
                    searchParams.StartWeight.Value > searchParams.EndWeight.Value)
                result.Error += "Start weight more than end one; ";

            if (string.IsNullOrEmpty(result.Error))
                result.Success = true;

            return result;
        }

        /// <summary>
        /// Get items from db and send emails
        /// </summary>
        /// <param name="query"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        internal static Task GetItemsAndSendEmailAsync(IEnumerable<CriminalPerson> query, string email)
        {
            return Task.Run(async () =>
            {
                try
                {
                    //get query items from db
                    var items = query.ToArray();

                    //make pdf attachments
                    var attachments = items.Select(x => PdfSharpModule.MakePdf(x)).ToList();

                    //get MaxItemsPerRequest from config file 
                    int maxItems = 0;
                    if (!int.TryParse(System.Configuration.ConfigurationManager.AppSettings["MaxItemsPerEmail"], out maxItems))
                        maxItems = MaxItemsPerEmail;

                    //async send email with attachments (max N items in email)
                    if (!attachments.Any())
                        await EmailSendManager.EmailSendAsync("No matches", email, "Criminal persons");

                    while (attachments.Any())
                    {
                        var attachmentsInEmail = attachments.Take(maxItems).ToArray();
                        //delete from whole collection
                        for (int i = 0; i < attachmentsInEmail.Length; i++)
                            attachments.Remove(attachmentsInEmail[i]);

                        await EmailSendManager.EmailSendAsync(String.Format("Search results: {0}", items.Length), email, "Criminal persons", attachmentsInEmail);
                    }

                    logger.Info("Succesfully sent emails to {0} with {1} attachments", email, items.Length);
                }
                catch (Exception ex)
                {
                    //log errors
                    logger.Error(ex);
                }
            });
        }

        /// <summary>
        /// Create linq query from SearchParams
        /// </summary>
        /// <param name="searchParams"></param>
        /// <param name="maxItems"></param>
        /// <param name="source"></param>
        /// <returns></returns>
        internal static IEnumerable<CriminalPerson> CreateQuery(SearchParams searchParams, int maxItems, IEnumerable<CriminalPerson> source)
        {
            IEnumerable<CriminalPerson> finalQuery = source.Take(maxItems);
            if (searchParams.Names != null && searchParams.Names.Any()) finalQuery = 
                    finalQuery.Intersect(source.Where(x => searchParams.Names.Any(y => String.Equals(y, x.Name, StringComparison.OrdinalIgnoreCase))));
            if (searchParams.StartAge.HasValue) finalQuery = finalQuery.Intersect(source.Where(x => x.Age >= searchParams.StartAge));
            if (searchParams.EndAge.HasValue) finalQuery = finalQuery.Intersect(source.Where(x => x.Age <= searchParams.EndAge));
            if (searchParams.StartHeight.HasValue) finalQuery = finalQuery.Intersect(source.Where(x => x.Height >= searchParams.StartHeight));
            if (searchParams.EndHeight.HasValue) finalQuery = finalQuery.Intersect(source.Where(x => x.Height <= searchParams.EndHeight));
            if (searchParams.StartWeight.HasValue) finalQuery = finalQuery.Intersect(source.Where(x => x.Weight >= searchParams.StartWeight));
            if (searchParams.EndWeight.HasValue) finalQuery = finalQuery.Intersect(source.Where(x => x.Weight <= searchParams.EndWeight));
            if (searchParams.Nationality != null && searchParams.Nationality.Any()) finalQuery = 
                    finalQuery.Intersect(source.Where(x => searchParams.Nationality.Any(y => String.Equals(y, x.Nationality, StringComparison.OrdinalIgnoreCase))));
            if (searchParams.Sex.HasValue) finalQuery = finalQuery.Intersect(source.Where(x => x.Sex == (Sex)searchParams.Sex));
            return finalQuery;
        }
    }
}