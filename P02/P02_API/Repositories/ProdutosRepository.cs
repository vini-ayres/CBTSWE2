using Microsoft.EntityFrameworkCore;
using P02_API.Abstractions;
using P02_API.Models;
using TP02.Context;

namespace P02_API.Repositories
{
    public class ProdutosRepository : RepositoryBase<Produto>, IProdutosRepository
    {
        public ProdutosRepository(ProvaContext context) : base(context)
        {
        }

        public override Task<Produto> GetById(int id)
        {
            var produto = DbSet.FirstOrDefaultAsync(e => e.Id == id);
            return produto;
        }

        public async Task Delete(int id)
        {
            var produto = await GetById(id);
            await base.Delete(produto);
        }
    }
}
