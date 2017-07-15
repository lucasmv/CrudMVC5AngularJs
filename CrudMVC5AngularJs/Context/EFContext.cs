using CrudMVC5AngularJs.EntityConfig;
using CrudMVC5AngularJs.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace CrudMVC5AngularJs.Context
{
    public class EFContext : DbContext
    {
        public DbSet<Celular> Celulares { get; set; }
        public DbSet<Operadora> Operadoras { get; set; }
        public DbSet<Contato> Contatos { get; set; }

        public EFContext() : base("CrudMVC5Angular") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties<string>().Configure(p => p.HasColumnType("varchar"));
            modelBuilder.Properties<string>().Configure(p => p.HasMaxLength(100));

            modelBuilder.Configurations.Add(new CelularConfig());
            modelBuilder.Configurations.Add(new ContatoConfig());
            modelBuilder.Configurations.Add(new OperadoraConfig());

            base.OnModelCreating(modelBuilder);
        }
    }
}