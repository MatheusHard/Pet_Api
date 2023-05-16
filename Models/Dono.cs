using System.ComponentModel.DataAnnotations;

namespace Pet_Api.Models
{
    public class Dono
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "O Campo {0} é Obrigatorio")]
        [StringLength(80, ErrorMessage = "O Campo {0} deve ter no minimo {2} caracteres", MinimumLength = 2)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O Campo {0} é Obrigatorio")]
        [StringLength(11, ErrorMessage = "O Campo {0} deve ter {11} caracteres", MinimumLength = 11)]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "O Campo {0} é Obrigatorio")]
        [StringLength(80, ErrorMessage = "O Campo {0} deve ter no minimo {2} caracteres", MinimumLength = 2)]
        public string User { get; set; }

        [Required(ErrorMessage = "O Campo {0} é Obrigatorio")]
        [StringLength(80, ErrorMessage = "O Campo {0} deve ter no minimo {2} caracteres", MinimumLength = 2)]
        public string Password { get; set; }
        public string CodigoRecuperacao { get; set; }
        public int qtdRowListagem { get; set; }
        public List<Pet>? Pets { get; set; }

    }
}
