using Microsoft.AspNetCore.Mvc;
using P02_API.Abstractions;
using P02_API.Models;

namespace P02_API.Controllers
{
    [ApiController]
    [Route("api/usuarios")]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuariosRepository _repository;

        public UsuariosController(IUsuariosRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Usuario usuario)
        {
            _repository.Create(usuario);
            return Created("", new object { });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(string login, string senha)
        {
            var usuario = await _repository.Login(login, senha);
            return Ok(usuario);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Find([FromRoute] int id)
        {
            var usuario = await _repository.GetById(id);
            return Ok(usuario);
        }

        [HttpGet]
        public async Task<IActionResult> Index([FromQuery] string name = null)
        {
            var atividades = string.IsNullOrEmpty(name)
                                ? await _repository.GetAll()
                                : await _repository.GetByName(name);
            return Ok(atividades);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] Usuario usuario)
        {
            var usuarioFind = await _repository.GetById(id);

            usuarioFind.Nome = usuario.Nome;
            usuarioFind.Senha = usuario.Senha;
            usuarioFind.Ativo = usuario.Ativo;

            _repository.Update(usuarioFind);
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