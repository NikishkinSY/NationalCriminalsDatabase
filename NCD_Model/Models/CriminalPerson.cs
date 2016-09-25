using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCD_Model
{
    public enum Sex
    {
        Male,
        Female
    }
    public class CriminalPerson
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public byte Age { get; set; }
        public Sex Sex { get; set; }
        [Range(0, 1000)]
        public int Height { get; set; }
        [Range(0, 1000)]
        public int Weight { get; set; }
        public string Nationality { get; set; }
    }
}
