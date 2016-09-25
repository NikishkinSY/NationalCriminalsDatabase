using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace NCD_WebService
{
    [ServiceContract]
    public interface ISearch
    {
        //Get criminal persons from database and send to user's email
        [OperationContract]
        Result GetCriminalPersons(SearchParams searchParams, int maxItems, string email);
    }

    /// <summary>
    /// Search parameters for query criminal persons
    /// </summary>
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

    /// <summary>
    /// Result with error message
    /// </summary>
    [DataContract]
    public class Result
    {
        [DataMember]
        public bool Success { get; set; }
        [DataMember]
        public string Error { get; set; }
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
