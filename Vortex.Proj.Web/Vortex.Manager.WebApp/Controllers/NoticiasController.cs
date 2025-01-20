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
    [Route("[controller]")]
    public class NoticiasController : Controller
    {
        private IHandler<RequestNoticiaDTO, Noticia> _handlerNoticias;
        private INoticiaService _noticiaService;
        private INoticiaTagService _noticiaTagService;

        public NoticiasController(IHandler<RequestNoticiaDTO, Noticia> handlerNoticias, INoticiaService noticiaService, INoticiaTagService noticiaTagService)
        {
            _handlerNoticias = handlerNoticias;
            _noticiaService = noticiaService;
            _noticiaTagService = noticiaTagService;
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get() => Ok(await _noticiaService.GetAsync().Result.Map());

        [HttpGet("GetNoticia/{id}")]
        public async Task<IActionResult> GetNoticia(int id) => Ok(await _noticiaService.GetAsync(id).Result.Map());

        [HttpPost("Create")]
        public async Task<IActionResult> Create(RequestNoticiaDTO dto)
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

        [HttpPut("Edit")]
        public async Task<IActionResult> Edit(RequestNoticiaDTO dto)
        {
            try
            {
                //Edit Noticia
                var noticia = await _handlerNoticias.ExecutarAsync(dto);
                noticia = await _noticiaService.UpdateAsync(noticia);

                //Relacionar com as Tags
                var tagsNoticias = await noticia.Map(dto.TagsId);
                await _noticiaTagService.RemoveAll(noticia.Id);
                await _noticiaTagService.AddAsync(tagsNoticias);

                return Ok(await _noticiaService.GetAsync(dto.Id).Result.Map());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _noticiaTagService.RemoveAll(id);
            await _noticiaService.RemoveAsync(id);
            return Ok(new {Id = id, Mensagem = "A Noticia Foi Excluida Com Sucesso!"});
        }
    }
}
