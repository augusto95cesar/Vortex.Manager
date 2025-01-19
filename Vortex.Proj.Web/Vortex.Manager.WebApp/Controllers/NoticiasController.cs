using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Vortex.Manager.Application.DTOs.Input.Noticia;
using Vortex.Manager.Application.DTOs.Output.Noticias;
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

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _noticiaService.GetAsync().Result.Map());

        [HttpPost]
        public async Task<IActionResult> Create(CreateNoticiaDTO dto)
        {
            try
            {
                //Criar Noticia
                var noticia = await _handlerNoticias.ExecutarAsync(dto);
                noticia = await _noticiaService.AddAsync(noticia);

                //Relacionar com as Tags
                var tagsNoticias = await noticia.Map(dto.TagsId);
                await _noticiaTagService.AddAsync(tagsNoticias);

                return CreatedAtAction(null, await _noticiaService.GetAsync(noticia.Id).Result.Map());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
