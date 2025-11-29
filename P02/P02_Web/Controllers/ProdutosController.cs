using Microsoft.AspNetCore.Mvc;
using P02_API_SDK.Dtos;
using P02_API_SDK.Services;
using P02_Web.Models;
using P02_Web.Utils;
using System.Diagnostics;

namespace P02_Web.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly ProdutosService produtosService;

        public ProdutosController(ProdutosService produtosService)
        {
            this.produtosService = produtosService;
        }

        public async Task<IActionResult> Index()
        {
            var user = Request.getCookieUser();
            if (user?.Id == null || user.Id <= 0)
            {
                return RedirectToAction("", "Autenticar");
            }

            var produtos = await produtosService.GetAll();
            return View(produtos);
        }

        public async Task<IActionResult> Details(int? id)
        {
            var user = Request.getCookieUser();
            if (user?.Id == null || user.Id <= 0)
            {
                return RedirectToAction("", "Autenticar");
            }

            var produto = await produtosService.GetById((int)id);

            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        public IActionResult Create()
        {
            var user = Request.getCookieUser();
            if (user?.Id == null || user.Id <= 0)
            {
                return RedirectToAction("", "Autenticar");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProdutoDTO produto)
        {
            if (ModelState.IsValid)
            {
                var user = Request.getCookieUser();
                produto.IdUsuarioCadastro = user.Id;
                await produtosService.Create(produto);
                return RedirectToAction(nameof(Index));
            }
            return View(produto);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            var user = Request.getCookieUser();
            if (user?.Id == null || user.Id <= 0)
            {
                return RedirectToAction("", "Autenticar");
            }
            var produto = await produtosService.GetById((int)id);

            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProdutoDTO produto)
        {
            if (ModelState.IsValid)
            {
                var user = Request.getCookieUser();
                produto.IdUsuarioUpdate = user.Id;
                await produtosService.Update((int)id, produto);
                return RedirectToAction(nameof(Index));
            }
            return View(produto);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            var produto = await produtosService.GetById((int)id);

            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await produtosService.Delete((int)id);
            return RedirectToAction(nameof(Index));
        }
    }
}