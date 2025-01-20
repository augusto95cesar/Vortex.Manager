using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        private IHandler<CreateTagDTO, Tag> _handlerTag;
        private ITagsService _service;

        public TagsController(IHandler<CreateTagDTO, Tag> handlerTag, ITagsService service)
        {
            _handlerTag = handlerTag;
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _service.GetALLAsync().Result.Map());
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTagDTO dto)
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
    }
}
