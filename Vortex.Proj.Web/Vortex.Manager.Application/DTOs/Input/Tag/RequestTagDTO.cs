using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Vortex.Manager.Application.DTOs.Input.Tag
{
    public class RequestTagDTO
    {
        public int Codigo { get; set; }

        [DisplayName("Descrição")]
        [MaxLength(100, ErrorMessage = "O campo Título pode ter no máximo 100 caracteres.")]
        public required string Descricao { get; set; }
    }
}
