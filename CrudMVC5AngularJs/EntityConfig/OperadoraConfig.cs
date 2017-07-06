using CrudMVC5AngularJs.Models;
using System.Data.Entity.ModelConfiguration;

namespace CrudMVC5AngularJs.EntityConfig
{
    public class OperadoraConfig : EntityTypeConfiguration<Operadora>
    {
        public OperadoraConfig()
        {
            HasKey(x => x.Id);

            Property(x => x.Nome).HasMaxLength(50);
            Property(x => x.Categoria).HasMaxLength(50);
        }
    }
}