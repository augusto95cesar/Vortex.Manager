using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Vortex.Manager.Application.DTOs.Input.Usuario;
using Microsoft.AspNetCore.Authorization; 

namespace Vortex.Manager.WebApp.Controllers
{
    public class AuthSystemController : Controller
    {
        // GET: AuthSystemController
        public async Task<ActionResult> IndexAsync()
        {
            await SignOutAsync();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> LoginAsync(LoginDTO dto)
        {
            try
            {
                await SignOutAsync();

                var usuario = dto;// _context.Usuarios.FirstOrDefault(u => u.Nome == nome && u.Senha == senha);

                if (usuario != null)
                {
                    var claims = new List<Claim> {
                    new Claim(ClaimTypes.Name, usuario.Email),
                    new Claim(ClaimTypes.Role, "Admin") // Adiciona o Role ao Claim
                };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", "Credenciais inválidas.");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await SignOutAsync();
            return RedirectToAction("Index");
        }

        private async Task SignOutAsync()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }

        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        [Authorize]
        // POST: AuthSystemController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateUsuarioDTO dto)
        {
            try
            {
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }
    }
}
