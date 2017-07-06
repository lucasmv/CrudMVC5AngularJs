using System;
using System.ComponentModel.DataAnnotations;

namespace CrudMVC5AngularJs.Models
{
    public class Contato
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public DateTime Data { get; set; }
        public int OperadoraId { get; set; }

        public Operadora Operadora { get; set; }
    }
}