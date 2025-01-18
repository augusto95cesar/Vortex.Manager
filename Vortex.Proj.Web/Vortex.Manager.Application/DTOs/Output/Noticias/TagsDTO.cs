using System.ComponentModel;

namespace Vortex.Manager.Application.DTOs.Output.Noticias
{
    public class TagsDTO
    {
        public int Id { get; set; }

        [DisplayName("Descrição")]
        public string Descricao { get; set; }
    }
}
