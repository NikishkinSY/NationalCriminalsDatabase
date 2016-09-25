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

namespace NCD_WebService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Search : ISearch
    {
        IContext DbContext { get; set; }
        public Search(IContext context)
        {
            DbContext = context;
        }
        public bool GetCriminalPersons(SearchParams searchParams, string email, out string result)
        {
            IEnumerable<CriminalPerson> finalQuery = DbContext.CriminalPersons;
            if (searchParams.Names != null && searchParams.Names.Any()) finalQuery = DbContext.CriminalPersons.Where(x => searchParams.Names.Contains(x.Name));
            if (searchParams.StartAge.HasValue) finalQuery = finalQuery.Union(DbContext.CriminalPersons.Where(x => x.Age >= searchParams.StartAge));
            if (searchParams.EndAge.HasValue) finalQuery = finalQuery.Union(DbContext.CriminalPersons.Where(x => x.Age <= searchParams.EndAge));
            if (searchParams.StartHeight.HasValue) finalQuery = finalQuery.Union(DbContext.CriminalPersons.Where(x => x.Height >= searchParams.StartHeight));
            if (searchParams.EndHeight.HasValue) finalQuery = finalQuery.Union(DbContext.CriminalPersons.Where(x => x.Height <= searchParams.EndHeight));
            if (searchParams.StartWeight.HasValue) finalQuery = finalQuery.Union(DbContext.CriminalPersons.Where(x => x.Weight >= searchParams.StartWeight));
            if (searchParams.EndWeight.HasValue) finalQuery = finalQuery.Union(DbContext.CriminalPersons.Where(x => x.Weight <= searchParams.EndWeight));
            if (searchParams.Nationality != null && searchParams.Nationality.Any()) finalQuery = finalQuery.Union(DbContext.CriminalPersons.Where(x => searchParams.Nationality.Contains(x.Nationality)));
            if (searchParams.Sex.HasValue) finalQuery = finalQuery.Union(DbContext.CriminalPersons.Where(x => x.Sex == (Sex)searchParams.Sex));
            var criminalPersons = finalQuery.ToArray();

            
            List<Attachment> attachments = new List<Attachment>();
            foreach (var item in criminalPersons)
            {
                var attachment = PdfSharp.MakePdf(item);
                attachments.Add(attachment);
            }
            
            EmailSendManager.EmailSendAsync("persons", email, "persons", attachments);


            result = string.Empty;
            return false;
        }

        public void SendEmail()
        {
        }
    }
}
