using CrudMVC5AngularJs.Models;
using System.Data.Entity.ModelConfiguration;

namespace CrudMVC5AngularJs.EntityConfig
{
    public class ContatoConfig : EntityTypeConfiguration<Contato>
    {
        public ContatoConfig()
        {
            HasKey(x => x.Id);

            HasRequired(x => x.Operadora);

            Property(x => x.Nome).HasMaxLength(50);
            Property(x => x.Telefone).HasMaxLength(50);
        }
    }
}