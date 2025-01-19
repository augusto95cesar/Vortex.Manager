using Vortex.Manager.Application.DTOs.Output.Noticias;
using Vortex.Manager.Application.DTOs.Output.Tag;
using Vortex.Manager.Domain.Entity;

namespace Vortex.Manager.Application.Mappers
{
    public static class NoticiaMapper
    {
        public static async Task<List<NoticiasDTO>> Map(this List<Noticia> noticias) => (await Task.Run(() =>
        {
            var r = new List<NoticiasDTO>();
            foreach (var noticia in noticias)
            {
                r.Add(MontarNoticia(noticia));
            }

            return r;
        }));

        public static async Task<List<NoticiasDTO>> Map(this Noticia noticia) => (await Task.Run(() => 
        { 
            return new List<NoticiasDTO> { MontarNoticia(noticia) }; 
        }));

        private static NoticiasDTO MontarNoticia(Noticia noticia)
        {
            return new NoticiasDTO
            {
                Codigo = noticia.Id,
                Descricao = noticia.Texto,
                Titulo = noticia.Titulo,
                Tags = MontarTags(noticia.NoticiaTag)
            };
        }

        private static List<TagsDTO> MontarTags(ICollection<NoticiaTag> noticiaTag)
        {
            var tags = new List<TagsDTO>();
            foreach (var tag in noticiaTag)
            {
                tags.Add(new TagsDTO
                {
                    Codigo = tag.Tag.Id,
                    Descricao = tag.Tag.Descricao
                });
            }

            return tags;
        }
    }
}
