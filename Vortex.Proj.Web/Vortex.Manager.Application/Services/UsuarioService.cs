using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Vortex.Manager.Application.Interfaces.Services;
using Vortex.Manager.Domain.Entity;
using Vortex.Manager.Infrastructure.Data.Interfaces; 

namespace Vortex.Manager.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private IHttpContextAccessor _httpContextAccessor;
        private IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _usuarioRepository = usuarioRepository;
        }
        public async Task<Usuario?> GetAsync(Usuario user)
        {
            return await _usuarioRepository.GetAsync(user);
        }

        public async Task<Usuario> GetUserLogado()
        {
            return await Task.Run(() =>
            {
                var usuario = _httpContextAccessor.HttpContext?.User;
                return new Usuario
                {
                    Id = int.Parse(usuario?.FindFirst("IdUser")?.Value),
                    Email = usuario?.FindFirst(ClaimTypes.Email)?.Value,
                    Nome = usuario?.FindFirst(ClaimTypes.Name)?.Value,
                    Senha = ""
                };
            });
        }
    }
}
