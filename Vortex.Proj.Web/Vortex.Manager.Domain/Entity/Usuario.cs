using System.ComponentModel.DataAnnotations;

namespace Vortex.Manager.Domain.Entity
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(250, ErrorMessage = "O campo Nome pode ter no máximo 250 caracteres.")]
        public required string Nome { get; set; }

        [MaxLength(50, ErrorMessage = "O campo Senha pode ter no máximo 50 caracteres.")]
        public required string Senha { get; set; }

        [MaxLength(250, ErrorMessage = "O campo E-Mail pode ter no máximo 250 caracteres.")]
        public required string Email { get; set; }

        //Relacionamento
        public required virtual ICollection<Noticia> Noticias { get; set; }
    }
}
