using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Collections;
using System.Collections.Generic;
using System.Text.Json;
using Vortex.Manager.Application.DTOs.Input.Tag;
using Vortex.Manager.Application.DTOs.Output.Tag;

namespace Vortex.Manager.WebApp.Controllers
{
    [Authorize]
    public class TagsController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            if (HttpContext.Session.GetString("ListaTags") != null)
            {
                var jsonString = HttpContext.Session.GetString("ListaTags");
                var lista = JsonSerializer.Deserialize<List<TagsDTO>>(jsonString);
                return Json(lista);
            }
            return Json(new List<TagsDTO>()); 
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTagDTO dto)
        {
            List<TagsDTO> lista;

            try
            {
                var jsonString = HttpContext.Session.GetString("ListaTags");
                lista = JsonSerializer.Deserialize<List<TagsDTO>>(jsonString);
                var id = lista.Count() + 1;
                lista.Add(new TagsDTO { Codigo = id, Descricao = dto.Descricao });

            }
            catch
            {
                lista = new List<TagsDTO> { new TagsDTO { Codigo = 1, Descricao = dto.Descricao } };
            }

            string json = JsonSerializer.Serialize(lista);
            HttpContext.Session.SetString("ListaTags", json);

            return Json(dto);
        }
    }
}
