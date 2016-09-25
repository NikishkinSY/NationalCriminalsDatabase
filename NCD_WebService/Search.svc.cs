using NCD_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using System.Net.Mail;
using System.IO;
using System.Net.Mime;
using NCD_EmailSend;
using System.Threading.Tasks;
using NLog;

namespace NCD_WebService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Search : ISearch
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        IContext DbContext { get; set; }
        public Search(IContext context)
        {
            DbContext = context;
            logger.Info("Search service started");
        }
        public Result GetCriminalPersons(SearchParams searchParams, int maxItems, string email)
        {
            var result = new Result();
            result.Error = string.Empty;

            if (!EmailSendManager.IsValidEmail(email))
                throw new Exception(String.Format("Email ({0}) is invalid; ", email));

            if (maxItems <= 0)
                throw new Exception(String.Format("Max items ({0}) must be greater than 0  is invalid; ", email));

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
            {
                var query = CreateQuery(searchParams, maxItems, DbContext.CriminalPersons);
                SendEmailAsync(query, email);
                result.Success = true;
            }
            
            return result;
        }

        /// <summary>
        /// Get items from db and send emails
        /// </summary>
        /// <param name="query"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        private Task SendEmailAsync(IEnumerable<CriminalPerson> query, string email)
        {
            return Task.Run(async () =>
            {
                try
                {
                    //get query items from db
                    var items = query.ToArray();
                    
                    //make pdf attachments
                    var attachments = items.Select(x => PdfSharp.MakePdf(x));

                    //async send email with attachments
                    await EmailSendManager.EmailSendAsync(String.Format("Search results: {0}", items.Length), email, "Criminal persons", attachments);
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
        private IEnumerable<CriminalPerson> CreateQuery(SearchParams searchParams, int maxItems, IEnumerable<CriminalPerson> source)
        {
            IEnumerable<CriminalPerson> finalQuery = source.Take(maxItems);
            if (searchParams.Names != null && searchParams.Names.Any()) finalQuery = finalQuery.Intersect(DbContext.CriminalPersons.Where(x => searchParams.Names.Contains(x.Name)));
            if (searchParams.StartAge.HasValue) finalQuery = finalQuery.Intersect(DbContext.CriminalPersons.Where(x => x.Age >= searchParams.StartAge));
            if (searchParams.EndAge.HasValue) finalQuery = finalQuery.Intersect(DbContext.CriminalPersons.Where(x => x.Age <= searchParams.EndAge));
            if (searchParams.StartHeight.HasValue) finalQuery = finalQuery.Intersect(DbContext.CriminalPersons.Where(x => x.Height >= searchParams.StartHeight));
            if (searchParams.EndHeight.HasValue) finalQuery = finalQuery.Intersect(DbContext.CriminalPersons.Where(x => x.Height <= searchParams.EndHeight));
            if (searchParams.StartWeight.HasValue) finalQuery = finalQuery.Intersect(DbContext.CriminalPersons.Where(x => x.Weight >= searchParams.StartWeight));
            if (searchParams.EndWeight.HasValue) finalQuery = finalQuery.Intersect(DbContext.CriminalPersons.Where(x => x.Weight <= searchParams.EndWeight));
            if (searchParams.Nationality != null && searchParams.Nationality.Any()) finalQuery = finalQuery.Intersect(DbContext.CriminalPersons.Where(x => searchParams.Nationality.Contains(x.Nationality)));
            if (searchParams.Sex.HasValue) finalQuery = finalQuery.Intersect(DbContext.CriminalPersons.Where(x => x.Sex == (Sex)searchParams.Sex));
            return finalQuery;
        }
    }
}
