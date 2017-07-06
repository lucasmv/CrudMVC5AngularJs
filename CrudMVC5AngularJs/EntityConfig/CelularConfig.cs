using CrudMVC5AngularJs.Models;
using System.Data.Entity.ModelConfiguration;

namespace CrudMVC5AngularJs.EntityConfig
{
    public class CelularConfig : EntityTypeConfiguration<Celular>
    {
        public CelularConfig()
        {
            HasKey(x => x.Id);

            Property(x => x.Marca).HasMaxLength(50);
            Property(x => x.Modelo).HasMaxLength(50);
            Property(x => x.Cor).HasMaxLength(50);
            Property(x => x.TipoChip).HasMaxLength(50);
            Property(x => x.MemoriaInterna).HasMaxLength(50);
        }
    }
}