using System.ComponentModel.DataAnnotations;

namespace CrudMVC5AngularJs.Models
{
    public class Operadora
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Codigo { get; set; }
        public string Categoria { get; set; }
    }
}