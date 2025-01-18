using Vortex.Manager.Domain.Entity;

namespace Vortex.Manager.Application.Interfaces.Services
{
    public interface INoticiaService
    {
        Task<Noticia> AddAsync(Noticia entrada);
    }
}
