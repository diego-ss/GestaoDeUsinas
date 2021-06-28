using System.ComponentModel.DataAnnotations;

namespace GestaoDeUsinas.Models
{
    public class Usina
    {
        public int Id { get; set; }

        [Required]
        public int FornecedorId { get; set; }

        //Join com a entidade de fornecedor
        public Fornecedor Fornecedor { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatório!")]
        [Display(Name = "UC da usina")]
        public string UCusina { get; set; }

        [Required]
        public bool Ativo { get; set; }
    }
}
