using Vortex.Manager.Application.DTOs.Input.Noticia;
using Vortex.Manager.Application.Interfaces;
using Vortex.Manager.Application.Interfaces.Services;
using Vortex.Manager.Domain.Entity;

namespace Vortex.Manager.Application.EventHandlers
{
    public class NoticiasHandler : IHandler<RequestNoticiaDTO, Noticia>
    {
        private IUsuarioService _usuarioService;

        public NoticiasHandler(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }
        public async Task<Noticia> ExecutarAsync(RequestNoticiaDTO dto)
        {
            var usuario = await _usuarioService.GetUserLogado();
            return await Task.Run(() =>
            {
                return new Noticia
                {
                    Id = dto.Id,
                    Titulo = dto.Titulo,
                    Texto = dto.Texto,
                    UsuarioId = usuario.Id
                };
            });
        }
    }
}
