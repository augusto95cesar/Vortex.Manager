using Vortex.Manager.Application.DTOs.Input.Tag;
using Vortex.Manager.Application.Interfaces;
using Vortex.Manager.Domain.Entity;

namespace Vortex.Manager.Application.EventHandlers
{
    public class TagsHandler : IHandler<CreateTagDTO, Tag>
    {
        public async Task<Tag> ExecutarAsync(CreateTagDTO entrada)
        {
            return await Task.Run(() =>
            {
                var tag = new Tag { Descricao = entrada.Descricao };
                return tag;
            });
        }
    }
}
