using NCD_Model;
using NLog;

namespace NCD_WebService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    [GlobalErrorBehavior(typeof(GlobalErrorHandler))]
    public class Search : ISearch
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private IContext _dbContext;
        public Search(IContext context)
        {
            _dbContext = context;
        }

        public Result GetCriminalPersons(SearchParams searchParams, int maxItems, string email)
        {
            //check input data
            var result = HelperModule.ValidateInputData(searchParams, maxItems, email);

            if (result.Success)
            {
                //create query
                var query = HelperModule.CreateQuery(searchParams, maxItems, _dbContext.CriminalPersons);

                //get items and send emails
                HelperModule.GetItemsAndSendEmailAsync(query, email);
            }

            return result;
        }
    }
}
