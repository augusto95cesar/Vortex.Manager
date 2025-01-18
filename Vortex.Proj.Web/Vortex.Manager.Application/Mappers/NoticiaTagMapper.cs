using Vortex.Manager.Domain.Entity;

namespace Vortex.Manager.Application.Mappers
{
    public static class NoticiaTagMapper
    {
        public static async Task<List<NoticiaTag>> Map(this Noticia noticia , List<int> tags)
        {
            return await Task.Run(() => {
                var r =  new List<NoticiaTag>();
                foreach (var tag in tags)
                    r.Add(new NoticiaTag { NoticiaId = noticia.Id, TagId = tag });
                return r;
            });
        }
    }
}
