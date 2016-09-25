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
    [GlobalErrorBehavior(typeof(GlobalErrorHandler))]
    public class Search : ISearch
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        IContext DbContext { get; set; }
        public Search(IContext context)
        {
            DbContext = context;
        }

        public Result GetCriminalPersons(SearchParams searchParams, int maxItems, string email)
        {
            //check input data
            var result = HelperModule.ValidateInputData(searchParams, maxItems, email);

            if (result.Success)
            {
                //create query
                var query = HelperModule.CreateQuery(searchParams, maxItems, DbContext.CriminalPersons);

                //get items and send emails
                HelperModule.GetItemsAndSendEmailAsync(query, email);
            }

            return result;
        }
    }
}
