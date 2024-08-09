using System;

namespace Product.CRUD.API.Models;

public interface IProductRepository
{
    Task<IEnumerable<Products>> GetProductsAsync();
    Task<Products> GetProductAsync(Guid id);
    Task<Products> CreateProductAsync(Products product);
    Task UpdateProductAsync(Products product);
    Task DeleteProductAsync(Products products);
}
