using Vortex.Manager.Domain.Entity;

namespace Vortex.Manager.Infrastructure.Data.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<Usuario?> GetAsync(Usuario entrada);
        Task<Usuario> AddAsync(Usuario user);
    }
}
