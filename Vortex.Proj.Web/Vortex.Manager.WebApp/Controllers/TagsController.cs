using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Vortex.Manager.Application.DTOs.Input.Tag;
using Vortex.Manager.Application.Interfaces;
using Vortex.Manager.Application.Interfaces.Services;
using Vortex.Manager.Application.Mappers; 
using Vortex.Manager.Domain.Entity;

namespace Vortex.Manager.WebApp.Controllers
{
    [Authorize] 
    public class TagsController : Controller
    {
        private IHandler<RequestTagDTO, Tag> _handlerTag;
        private ITagsService _service;
        private INoticiaTagService _noticiaTagService;

        public TagsController(IHandler<RequestTagDTO, Tag> handlerTag, ITagsService service, INoticiaTagService noticiaTagService)
        {
            _handlerTag = handlerTag;
            _service = service;
            _noticiaTagService = noticiaTagService;
        }

        public async Task<IActionResult> Index()
        {
            if (User.FindFirstValue(ClaimTypes.Email).Equals("master@gmail.com")) 
                return View(await _service.GetALLAsync().Result.Map());


            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _service.GetALLAsync().Result.Map());
        }

        [HttpPost]
        public async Task<IActionResult> Create(RequestTagDTO dto)
        {
            try
            {
                var tag = await _handlerTag.ExecutarAsync(dto);
                tag = await _service.AddAsync(tag);
                var result = await tag.Map();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put(RequestTagDTO dto)
        {
            try
            {
                var tag = await _handlerTag.ExecutarAsync(dto);
                tag = await _service.UpdateAsync(tag);
                var result = await tag.Map();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _noticiaTagService.RemoveTagAll(id);
                await _service.RemoveAsync(id);
                return Ok(new { Id = id, Mensagem = "A tag foi removida com sucesso!" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
