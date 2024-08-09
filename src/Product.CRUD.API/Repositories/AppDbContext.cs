using System;
using Microsoft.EntityFrameworkCore;
using Product.CRUD.API.Models;

namespace Product.CRUD.API.Repositories;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Products> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Products>().ToTable("products");
    }

}
