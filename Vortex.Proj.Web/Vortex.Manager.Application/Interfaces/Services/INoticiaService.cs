using Vortex.Manager.Domain.Entity;

namespace Vortex.Manager.Application.Interfaces.Services
{
    public interface INoticiaService
    {
        Task<Noticia?> GetAsync(int entrada);
        Task<List<Noticia>> GetAsync();
        Task<Noticia> AddAsync(Noticia entrada);
        Task<Noticia> UpdateAsync(Noticia entrada);
        Task RemoveAsync(int entrada);
    }
}
