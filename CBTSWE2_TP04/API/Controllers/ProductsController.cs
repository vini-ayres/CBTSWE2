using Application.Repositorys;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;

namespace API.Controllers
{
    [Route("products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductRepository productRepository;

        public ProductsController(ProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var products = await productRepository.Index();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            var product = await productRepository.Details(id);
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            var sucesso = await productRepository.Create(product);
            if (sucesso)
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, Product product)
        {
            var sucesso = await productRepository.Edit(id, product);
            if (sucesso)
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var sucesso = await productRepository.Delete(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
