using Microsoft.EntityFrameworkCore;
using TP02.Context;

namespace P02_API.Abstractions;

public interface IRepositoryBase<T> where T : class
{
    Task<T> GetById(int id);
    Task<List<T>> GetAll();
    Task Create(T entity);
    Task Update(T entity);
    Task Delete(T entity);
}