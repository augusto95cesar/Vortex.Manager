using Vortex.Manager.Application.DTOs.Input.Noticia;
using Vortex.Manager.Application.Interfaces;
using Vortex.Manager.Application.Interfaces.Services;
using Vortex.Manager.Domain.Entity;

namespace Vortex.Manager.Application.EventHandlers
{
    public class NoticiasHandler : IHandler<CreateNoticiaDTO, Noticia>
    {
        private IUsuarioService _usuarioService;

        public NoticiasHandler(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }
        public async Task<Noticia> ExecutarAsync(CreateNoticiaDTO dto)
        {
            var usuario = await _usuarioService.GetUserLogado();
            return await Task.Run(() =>
            {
                return new Noticia
                {
                    Titulo = dto.Titulo,
                    Texto = dto.Texto,
                    UsuarioId = usuario.Id
                };
            });
        }
    }
}
