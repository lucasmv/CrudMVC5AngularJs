using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace CrudMVC5AngularJs.Models
{
    public class CelularDbContext : DbContext
    {
        public DbSet<Celular> Celulares { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}