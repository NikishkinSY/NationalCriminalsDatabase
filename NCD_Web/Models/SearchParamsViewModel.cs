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

        [Range(0, 255, ErrorMessage = "Height must be between 0 and 255")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Age must be numeric")]
        [Display(Name = "Start age")]
        public byte? StartAge { get; set; }

        [Range(0, 255, ErrorMessage = "Height must be between 0 and 255")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Age must be numeric")]
        [Display(Name = "End age")]
        public byte? EndAge { get; set; }

        public Sex? Sex { get; set; }

        [Range(0, 1000, ErrorMessage = "Height must be between 0 and 1000")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Height must be numeric")]
        [Display(Name = "Start height")]
        public int? StartHeight { get; set; }

        [Range(0, 1000, ErrorMessage = "Height must be between 0 and 1000")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Height must be numeric")]
        [Display(Name = "End height")]
        public int? EndHeight { get; set; }

        [Range(0, 1000, ErrorMessage = "Weight must be between 0 and 1000")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Weight must be numeric")]
        [Display(Name = "Start weight")]
        public int? StartWeight { get; set; }

        [Range(0, 1000, ErrorMessage = "Weight must be between 0 and 1000")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Weight must be numeric")]
        [Display(Name = "End weight")]
        public int? EndWeight { get; set; }

        
        [Display(Name = "Nationality")]
        public string Nationality { get; set; }
    }
}