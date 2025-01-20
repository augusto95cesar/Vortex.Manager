using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Vortex.Manager.Application.DTOs.Input.Noticia
{
    public class RequestNoticiaDTO
    {
        public int Id { get; set; }

        [DisplayName("Título")]
        [MaxLength(250, ErrorMessage = "O campo Título pode ter no máximo 250 caracteres.")]
        public required string Titulo { get; set; }

        [DisplayName("Descrição")]
        public required string Texto { get; set; }

        public required List<int> TagsId { get; set; } 
    }
}
