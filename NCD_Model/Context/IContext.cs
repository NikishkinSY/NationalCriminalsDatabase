using System.Data.Entity;

namespace NCD_Model
{
    public interface IContext
    {
        DbSet<CriminalPerson> CriminalPersons { get; set; }
    }
}
