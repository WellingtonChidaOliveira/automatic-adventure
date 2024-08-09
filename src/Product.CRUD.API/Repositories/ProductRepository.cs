using System;
using Microsoft.EntityFrameworkCore;
using Product.CRUD.API.Models;

namespace Product.CRUD.API.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly DbSet<Products> _products;
    private readonly AppDbContext _dbContext;
    public ProductRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
        _products = dbContext.Products;
    }

    public async Task<Products> CreateProductAsync(Products product)
    {
        await _products.AddAsync(product);
        await SaveChanges();
        return product;
    }

    public async Task DeleteProductAsync(Products prodocut)
    {
        _products.Remove(prodocut);
        await SaveChanges();
    }

    public async Task<Products> GetProductAsync(Guid id)
    {
        return await _products.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<IEnumerable<Products>> GetProductsAsync()
    {
        return await _products.AsNoTracking().ToListAsync();
    }

    public async Task UpdateProductAsync(Products product)
    {
        _products.Update(product);
        await SaveChanges();
    }

    private async Task SaveChanges()
    {
        await _dbContext.SaveChangesAsync();
    }
}
