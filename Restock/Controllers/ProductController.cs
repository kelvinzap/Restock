using Microsoft.AspNetCore.Mvc;
using Restock.Contracts.v1.Request;
using Restock.Contracts.v1.Response;
using Restock.Helpers;
using Restock.Models;
using Restock.Repositories;
using Restock.Services;

namespace Restock.Controllers;

[ApiController]
[Route("api/products/")]
public class ProductController : ControllerBase
{
    private readonly IProductRepository _productRepository;
    private readonly IUriService _uriService;

    public ProductController(IProductRepository productRepository, IUriService uriService)
    {
        _productRepository = productRepository;
        _uriService = uriService;
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
            CategoryId = model.Category,
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
    public IActionResult GetAllProducts([FromQuery] PaginationQuery query)
    {
        var pagination = new PaginationFilter
        {
            PageNumber = query.PageNumber,
            PageSize = query.PageSize
        };

        var products = _productRepository.GetAllProducts(pagination);

        var productsResponse = new List<ProductResponse>();
        
        products.ForEach(product =>
        {
            productsResponse.Add(new ProductResponse
            {
                Category = product.CategoryId,
                InStock = product.InStock,
                Description = product.Description,
                ImageUrl = product.ImageUrl,
                Id = product.Id,
                CreatedAt = product.CreatedAt,
                Name = product.Name,
                Price = product.Price,
                IsAvailable = product.IsAvailable,
                UpdatedAt = product.UpdatedAt,
                UserId = product.UserId
            });
        });
        
        //Returns the default page
        if (pagination is null || pagination.PageNumber < 1 || pagination.PageSize < 1)
        {
            return Ok(new PagedResponse<ProductResponse>(productsResponse));
        }
        
        var paginationResponse = PaginationHelpers.CreatePaginatedResponse(_uriService, pagination, productsResponse);
        return Ok(paginationResponse);
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