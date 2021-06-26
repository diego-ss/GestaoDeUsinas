using System.ComponentModel.DataAnnotations;

namespace GestaoDeUsinas.Models
{
    public class Fornecedor
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }
    }
}
