using Microsoft.EntityFrameworkCore;
using P02_API.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace TP02.Context;

public class ProvaContext : DbContext
{
    public ProvaContext(DbContextOptions<ProvaContext> options) : base(options)
    {
    }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Produto> Produtos { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Usuario>().HasKey(m => m.Id);
        builder.Entity<Produto>().HasKey(m => m.Id);

        base.OnModelCreating(builder);
    }
}
