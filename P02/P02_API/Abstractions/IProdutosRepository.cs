using Microsoft.EntityFrameworkCore;
using P02_API.Models;
using TP02.Context;

namespace P02_API.Abstractions;

public interface IProdutosRepository : IRepositoryBase<Produto>
{
    Task Delete(int id);
}