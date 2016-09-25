using NCD_Model;
using NCD_Web.NCD_Service;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NCD_Web.Models
{
    public class SearchParamsViewModel
    {
        public string Names { get; set; }
        [Display(Name = "Start age")]
        public byte? StartAge { get; set; }
        [Display(Name = "End age")]
        public byte? EndAge { get; set; }
        public Sex? Sex { get; set; }
        [Display(Name = "Start height")]
        public ushort? StartHeight { get; set; }
        [Display(Name = "End height")]
        public ushort? EndHeight { get; set; }
        [Display(Name = "Start width")]
        public ushort? StartWeight { get; set; }
        [Display(Name = "End width")]
        public ushort? EndWeight { get; set; }
        [Display(Name = "Nationality")]
        public string Nationality { get; set; }
    }
}