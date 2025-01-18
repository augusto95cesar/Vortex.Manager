using Vortex.Manager.Domain.Entity;

namespace Vortex.Manager.Application.Interfaces.Services
{
    public interface IUsuarioService
    {
        Task<Usuario?> GetAsync(Usuario entrada);
        Task<Usuario> GetUserLogado();
    }
}
