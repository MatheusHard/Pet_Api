using System.ComponentModel.DataAnnotations;

namespace Pet_Api.Models
{
    public class Pet
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "O Campo {0} é Obrigatorio")]
        [StringLength(80, ErrorMessage = "O Campo {0} deve ter no minimo {2} caracteres", MinimumLength = 2)]
        public string Nome { get; set; }
        public int TipoPetId { get; set; }
        public virtual TipoPet? TipoPet { get; set; }
        public DateTime DataNascimento { get; set; }
        public bool Sexo { get; set; }
        public virtual Dono? Dono { get; set; }
        public int DonoId { get; set; }
        
    }
}
