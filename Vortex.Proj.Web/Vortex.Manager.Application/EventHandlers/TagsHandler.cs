using Vortex.Manager.Application.DTOs.Input.Tag;
using Vortex.Manager.Application.Interfaces;
using Vortex.Manager.Domain.Entity;

namespace Vortex.Manager.Application.EventHandlers
{
    public class TagsHandler : IHandler<RequestTagDTO, Tag>
    {
        public async Task<Tag> ExecutarAsync(RequestTagDTO dto)
        {
            return await Task.Run(() =>
            {
                var tag = new Tag { Id = dto.Codigo, Descricao = dto.Descricao };
                return tag;
            });
        }
    }
}
