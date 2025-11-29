using Microsoft.EntityFrameworkCore;
using P02_API.Models;
using TP02.Context;

namespace P02_API.Abstractions;

public interface IUsuariosRepository : IRepositoryBase<Usuario>
{
    Task Delete(int id);
    Task<List<Usuario>> GetByName(string name);
    Task<Usuario> Login(string name, string senha);
}