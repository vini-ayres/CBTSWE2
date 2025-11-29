using Microsoft.AspNetCore.Mvc;
using P02_API_SDK.Dtos;
using P02_API_SDK.Services;
using P02_Web.Models;
using P02_Web.Utils;
using System.Diagnostics;

namespace P02_Web.Controllers
{
    public class AutenticarController : Controller
    {
        private readonly UsuariosService usuariosService;

        public AutenticarController(UsuariosService usuariosService)
        {
            this.usuariosService = usuariosService;
        }

        public async Task<IActionResult> Index(AutenticarDTO autenticar)
        {
            return View(autenticar);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logar(AutenticarDTO autenticar)
        {
            if (ModelState.IsValid)
            {
                var usuario = await usuariosService.Login(autenticar.Login, autenticar.Senha);

                if (usuario == null)
                {
                    Response.toClearCookieUser();
                    return View("Index", autenticar);
                }

                Response.toSaveCookieUser(usuario);
              
                return RedirectToAction("", "Produtos");
            }
            return View("Index", autenticar);
        }

        public IActionResult Sair()
        {
            Response.toClearCookieUser();
            return RedirectToAction("Index");
        }
    }
}