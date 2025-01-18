using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vortex.Manager.Application.DTOs.Input.Noticia;
using Vortex.Manager.Application.Interfaces;
using Vortex.Manager.Application.Interfaces.Services;
using Vortex.Manager.Application.Mappers;
using Vortex.Manager.Application.Services;
using Vortex.Manager.Domain.Entity;

namespace Vortex.Manager.WebApp.Controllers
{
    [Authorize]
    public class NoticiasController : Controller
    {
        private IHandler<CreateNoticiaDTO, Noticia> _handlerNoticias;
        private INoticiaService _noticiaService;
        private INoticiaTagService _noticiaTagService;

        public NoticiasController(IHandler<CreateNoticiaDTO, Noticia> handlerNoticias, INoticiaService noticiaService, INoticiaTagService noticiaTagService)
        {
            _handlerNoticias = handlerNoticias;
            _noticiaService = noticiaService;
            _noticiaTagService = noticiaTagService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateNoticiaDTO dto)
        {
            //Criar Noticia
            var noticia = await _handlerNoticias.ExecutarAsync(dto);
            noticia = await _noticiaService.AddAsync(noticia);

            //Relacionar com as Tags
            var tagsNoticias = await noticia.Map(dto.TagsId);
            await _noticiaTagService.AddAsync(tagsNoticias);

            return Ok();
        }
    }
}
