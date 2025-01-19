using Vortex.Manager.Application.DTOs.Output.Tag;
using Vortex.Manager.Domain.Entity;

namespace Vortex.Manager.Application.Mappers
{
    public static class TagMapper
    {
        public async static Task<List<TagsDTO>> Map(this List<Tag> l) => (await Task.Run(() =>
        {
            var r = new List<TagsDTO>();
            foreach (var tag in l)
                r.Add(new TagsDTO { Codigo = tag.Id, Descricao = tag.Descricao });

            return r;
        }));

        public async static Task<TagsDTO> Map(this Tag tag) => (await Task.Run(() =>
        {
            if (tag != null)
                return new TagsDTO { Codigo = tag.Id, Descricao = tag.Descricao };
            else
                return new TagsDTO();
        }));

    }
}
