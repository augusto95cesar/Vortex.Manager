using System.ComponentModel.DataAnnotations;

namespace Vortex.Manager.Domain.Entity
{
    public class Tag
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(100, ErrorMessage = "O campo Descrição pode ter no máximo 100 caracteres.")]
        public required string Descricao { get; set; }

        //Relacionamento
        public required virtual ICollection<NoticiaTag> Noticias { get; set; } // Habilita o lazy loading
    }
}
