using Microsoft.AspNetCore.Mvc;
using Product.CRUD.API.Models;

namespace Product.CRUD.API.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Products>>> GetProductsAsync()
        {
            var products = await _productRepository.GetProductsAsync();
            return Ok(products);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetProductByIdAsync(Guid id)
        {
            var product = await _productRepository.GetProductAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult> CreateProductAsync(ProductRequest productRequest)
        {
            var product = new Products(productRequest.name, productRequest.description);
            var createdProduct = await _productRepository.CreateProductAsync(product);
            // return CreatedAtAction(nameof(GetProductByIdAsync), new { id = createdProduct.Id }, createdProduct); TODO: fix
            return Ok(createdProduct);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProductAsync(Guid id, Products product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            await _productRepository.UpdateProductAsync(product);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProductAsync(Guid id)
        {
            var product = await _productRepository.GetProductAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            await _productRepository.DeleteProductAsync(product);
            return NoContent();
        }


        public record ProductRequest (string name, string description);
    }
}
