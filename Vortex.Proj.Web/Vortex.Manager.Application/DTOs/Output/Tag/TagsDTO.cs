using System.ComponentModel;

namespace Vortex.Manager.Application.DTOs.Output.Tag
{
    public class TagsDTO
    {
        [DisplayName("Código")]
        public int Codigo { get; set; }

        [DisplayName("Descrição")]
        public string Descricao { get; set; }
    }
}
