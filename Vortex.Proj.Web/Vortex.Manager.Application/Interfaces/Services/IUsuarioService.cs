using Vortex.Manager.Domain.Entity;

namespace Vortex.Manager.Application.Interfaces.Services
{
    public interface IUsuarioService
    {
        Task<Usuario> AddAsync(Usuario entrada);
        Task<Usuario?> GetAsync(Usuario entrada);
        Task<Usuario> GetUserLogado();
    }
}
