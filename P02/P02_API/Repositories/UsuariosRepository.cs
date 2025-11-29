using Microsoft.EntityFrameworkCore;
using P02_API.Abstractions;
using P02_API.Models;
using TP02.Context;

namespace P02_API.Repositories
{
    public class UsuariosRepository : RepositoryBase<Usuario>, IUsuariosRepository
    {
        public UsuariosRepository(ProvaContext context) : base(context)
        {
        }

        public override Task<Usuario> GetById(int id)
        {
            var usuario = DbSet.FirstOrDefaultAsync(e => e.Id == id);
            return usuario;
        }

        public async Task Delete(int id)
        {
            var produto = await GetById(id);
            await base.Delete(produto);
        }

        public async Task<List<Usuario>> GetByName(string name)
        {
            var usuarios = await DbSet.Where(e => e.Nome.ToLower().Contains(name.ToLower())).ToListAsync();
            return usuarios;
        }

        public async Task<Usuario> Login(string name, string senha)
        {
            var usuario = await DbSet.FirstOrDefaultAsync(e => e.Nome == name && e.Senha == senha && e.Ativo);
            return usuario;
        }
    }
}
