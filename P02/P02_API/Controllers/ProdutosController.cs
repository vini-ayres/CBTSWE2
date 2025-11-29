using Microsoft.AspNetCore.Mvc;
using P02_API.Abstractions;
using P02_API.Models;

namespace P02_API.Controllers
{
    [ApiController]
    [Route("api/produtos")]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutosRepository _repository;

        public ProdutosController(IProdutosRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Produto produto)
        {
            _repository.Create(produto);
            return Created("", new object { });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Find([FromRoute] int id)
        {
            var produto = await _repository.GetById(id);
            return Ok(produto);
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var atividades = await _repository.GetAll();
            return Ok(atividades);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] Produto produto)
        {
            var produtoFind = await _repository.GetById(id);

            produtoFind.Nome = produto.Nome;
            produtoFind.Preco = produto.Preco;
            produtoFind.Ativo = produto.Ativo;
            produtoFind.IdUsuarioUpdate = produto.IdUsuarioUpdate;

            _repository.Update(produtoFind);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove([FromRoute] int id)
        {
            _repository.Delete(id);
            return NoContent();
        }
    }
}