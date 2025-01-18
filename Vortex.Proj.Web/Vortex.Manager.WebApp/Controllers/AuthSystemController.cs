using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Vortex.Manager.Application.DTOs.Input.Usuario;
using Microsoft.AspNetCore.Authorization;
using Vortex.Manager.Application.Interfaces.Services;
using Vortex.Manager.Application.Services;
using Vortex.Manager.Domain.Entity;

namespace Vortex.Manager.WebApp.Controllers
{
    public class AuthSystemController : Controller
    {
        private IUsuarioService _usuarioSerivce;

        public AuthSystemController(IUsuarioService usuarioSerivce)
        {
            _usuarioSerivce = usuarioSerivce;
        }

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

                Usuario? usuario = new Usuario { Id = 1, Email = dto.Email, Senha = dto.Password };
                //usuario = await _usuarioSerivce.GetAsync(usuario);

                if (usuario != null)
                {
                    var claims = new List<Claim>();
                    claims.Add(new Claim(ClaimTypes.Email, usuario.Email));
                    claims.Add(new Claim(ClaimTypes.Name, usuario?.Nome ?? ""));
                    claims.Add(new Claim(ClaimTypes.Role, "Admin"));
                    claims.Add(new Claim("IdUser", $"{usuario.Id}"));

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
