using NCD_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

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
        public bool GetCriminalPersons(SearchParams searchParams, out string result)
        {
            IEnumerable<CriminalPerson> finalQuery = DbContext.CriminalPersons;

            if (searchParams.Names.Any())
                finalQuery = DbContext.CriminalPersons.Where(x => searchParams.Names.Contains(x.Name));

            if (searchParams.StartAge.HasValue)
                finalQuery = DbContext.CriminalPersons.Where(x => searchParams.StartAge <= x.Age);

            result = string.Empty;
            return false;
        }
    }
}
