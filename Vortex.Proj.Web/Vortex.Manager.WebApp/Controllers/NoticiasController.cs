using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vortex.Manager.Application.DTOs.Output.Noticias;

namespace Vortex.Manager.WebApp.Controllers
{
    public class NoticiasController : Controller
    {
        // GET: NoticiasController
        public ActionResult Index()
        {
            return View(new List<TagsDTO> { new TagsDTO { Id = 1, Descricao = "Tag 01" }, new TagsDTO { Descricao = "Tag 02", Id = 2 }});
        }

        // GET: NoticiasController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: NoticiasController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NoticiasController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: NoticiasController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: NoticiasController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: NoticiasController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: NoticiasController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
