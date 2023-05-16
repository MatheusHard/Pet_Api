using System.ComponentModel.DataAnnotations;

namespace Pet_Api.Models
{
    public class TipoPet
    {
        [Key]
        public int Id { get; set; }

        [Required (ErrorMessage = "O Campo {0} é Obrigatorio")]
        [StringLength (80, ErrorMessage = "O Campo {0} deve ter no minimo {2} caracteres", MinimumLength = 2)]
        public string Descricao { get; set; }

       // [Required(ErrorMessage = "O Campo {0} é Obrigatorio")]
        //[StringLength(11, ErrorMessage = "O Campo {0} deve ter no minimo {2} caracteres", MinimumLength = 11)]
    }
}
