using Vortex.Manager.Domain.Entity;

namespace Vortex.Manager.Application.Interfaces.Services
{
    public interface INoticiaTagService
    {
        Task AddAsync(List<NoticiaTag> entrada);
    }
}
