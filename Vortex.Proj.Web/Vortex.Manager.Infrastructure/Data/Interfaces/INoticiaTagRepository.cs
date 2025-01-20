using Vortex.Manager.Domain.Entity;

namespace Vortex.Manager.Infrastructure.Data.Interfaces
{
    public interface INoticiaTagRepository
    {
        Task<NoticiaTag> AddAsync(NoticiaTag entrada);
        Task RemoveAll(int noticiaId);
    }
}
