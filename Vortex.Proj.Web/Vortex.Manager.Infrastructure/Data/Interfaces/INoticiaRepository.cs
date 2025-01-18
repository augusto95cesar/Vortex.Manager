using Vortex.Manager.Domain.Entity;

namespace Vortex.Manager.Infrastructure.Data.Interfaces
{
    public interface INoticiaRepository
    {
        Task<Noticia> AddAsync(Noticia entrada);
    }
}
