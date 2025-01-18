using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Vortex.Manager.Domain.Entity;
using System.ComponentModel;

namespace Vortex.Manager.Application.DTOs.Input.Noticia
{
    public class CreateNoticiaDTO
    {

        [DisplayName("Título")]
        [MaxLength(250, ErrorMessage = "O campo Título pode ter no máximo 250 caracteres.")]
        public required string Titulo { get; set; }

        [DisplayName("Descrição")]
        public required string Texto { get; set; }

        public required List<int> TagId { get; set; } 
    }
}
