using Vortex.Manager.Domain.Entity;

namespace Vortex.Manager.Infrastructure.Data.Interfaces
{
    public interface INoticiaRepository
    {
        Task<Noticia?> GetAsync(int entrada);
        Task<List<Noticia>> GetAllAsync(int entrada);
        Task<Noticia> AddAsync(Noticia entrada);
        Task<Noticia> UpdateAsync(Noticia entrada);
        Task RemoveAsync(int entrada);
    }
}
