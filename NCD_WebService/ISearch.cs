using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace NCD_WebService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface ISearch
    {
        [OperationContract]
        bool GetCriminalPersons(SearchParams searchParams, string email, out string result);
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class SearchParams
    {
        [DataMember]
        public string[] Names { get; set; }
        [DataMember]
        public byte? StartAge { get; set; }
        [DataMember]
        public byte? EndAge { get; set; }
        [DataMember]
        public int? Sex { get; set; }
        [DataMember]
        public ushort? StartHeight { get; set; }
        [DataMember]
        public ushort? EndHeight { get; set; }
        [DataMember]
        public ushort? StartWeight { get; set; }
        [DataMember]
        public ushort? EndWeight { get; set; }
        [DataMember]
        public string[] Nationality { get; set; }
    }

    //[DataContract]
    //public enum Sex
    //{
    //    [EnumMember]
    //    Male,
    //    [EnumMember]
    //    Female
    //}
}
