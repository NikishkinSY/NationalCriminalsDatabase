using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace NCD_Model
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IContext
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<CriminalPerson> CriminalPersons { get; set; }
    }
}