using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCD_Model
{
    public interface IContext
    {
        DbSet<CriminalPerson> CriminalPersons { get; set; }
    }
}
