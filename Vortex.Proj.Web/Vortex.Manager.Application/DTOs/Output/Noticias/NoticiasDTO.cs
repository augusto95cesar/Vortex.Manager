using Vortex.Manager.Application.DTOs.Output.Tag;

namespace Vortex.Manager.Application.DTOs.Output.Noticias
{
    public class NoticiasDTO
    {
        public int Codigo { get; set; } 
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public List<TagsDTO> Tags { get; set; }
    }
}
