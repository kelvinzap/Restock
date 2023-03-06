using Microsoft.AspNetCore.Mvc;
using Restock.Contracts.v1.Request;
using Restock.Models;
using Restock.Repositories;
using Restock.Services;

namespace Restock.Controllers;

[ApiController]
[Route("api/products/")]
public class ProductController : ControllerBase
{
    private readonly IProductRepository _productRepository;
    private readonly ICartService _cartService;

    public ProductController(IProductRepository productRepository, ICartService cartService)
    {
        _productRepository = productRepository;
        _cartService = cartService;
    }

    [HttpPost("createProduct")]
    public IActionResult CreateProduct([FromBody] CreateProductRequest model)
    {
        if (model is null)
            return BadRequest();

        if (model.InStock <= 0)
            return BadRequest();
        
        var product = new ProductModel() 
        {
            Id = Guid.NewGuid().ToString(),
            Category = model.Category,
            CreatedAt = DateTime.UtcNow,
            Description = model.Description,
            ImageUrl = model.ImageUrl,
            InStock = model.InStock,
            Name = model.Name,
            Price = model.Price,
            IsAvailable = true
        };
        
        var created = _productRepository.CreateProduct(product);

        return !created ? BadRequest(new {error = "Something went wrong bro"}) : Ok(product);

    }

    [HttpGet("getAllProducts")]
    public IActionResult GetAllProducts()
    {
        return Ok();
    }

    [HttpGet("getProduct/{id}")]
    public IActionResult GetProduct([FromRoute] string id)
    {
        var product = _productRepository.GetProduct(id);
        return product is null ? NotFound() : Ok(product);
    }

    [HttpPut("updateProduct/{id}")]
    public IActionResult UpdateProduct([FromRoute] string id, [FromBody] UpdateProductRequest model)
    {
        var updated = _productRepository.UpdateProduct(id, model);
        return updated ? Ok(model) : BadRequest(new { custom = "Something went wrong" });
    }
    
    [HttpDelete("deleteProduct/{id}")]
    private IActionResult DeleteProduct([FromRoute] string id)
    {
        var deleted = _productRepository.DeleteProduct(id);
        return !deleted ? NotFound() : NoContent();
    }
}