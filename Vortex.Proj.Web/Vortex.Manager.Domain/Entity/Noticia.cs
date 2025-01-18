using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vortex.Manager.Domain.Entity
{
    public class Noticia
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(250, ErrorMessage = "O campo Título pode ter no máximo 250 caracteres.")]
        public required string Titulo { get; set; }
        public required string Texto { get; set; }
        public required int UsuarioId { get; set; }

        //Relacionamento
        [ForeignKey("UsuarioId")]
        public virtual Usuario Usuario { get; set; }
        public virtual ICollection<NoticiaTag> NoticiaTag { get; set; }
    }
}
