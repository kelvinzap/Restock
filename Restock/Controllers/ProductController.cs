using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restock.Contracts.v1.Request;
using Restock.Contracts.v1.Response;
using Restock.Extension;
using Restock.Helpers;
using Restock.Models;
using Restock.Repositories;
using Restock.Services;

namespace Restock.Controllers;

[ApiController]
[Route("api/products/")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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
    public async Task<IActionResult> CreateProduct([FromBody] CreateProductRequest model)
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
            IsAvailable = true,
            UserId = HttpContext.GetUserId()
        };
        
        var created = await _productRepository.CreateProduct(product);

        if (!created)
            return BadRequest(new {error = "Invalid Request" });

        var locationUri = _uriService.GetProductUri((product.Id));
        return Created(locationUri, product);
    }

    [HttpGet("getAllProducts")]
    public async Task<IActionResult> GetAllProducts([FromQuery] PaginationQuery query)
    {
        var pagination = new PaginationFilter
        {
            PageNumber = query.PageNumber,
            PageSize = query.PageSize
        };

        var products = await _productRepository.GetAllProducts(pagination);

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
    public async Task<IActionResult> GetProduct([FromRoute] string id)
    {
        var product = await _productRepository.GetProductById(id);
        return product is null ? NotFound() : Ok(product);
    }

    [HttpPut("updateProduct/{id}")]
    public async Task<IActionResult> UpdateProduct([FromRoute] string id, [FromBody] UpdateProductRequest model)
    {

        var productInDb = await _productRepository.GetProductById(id);

        if (productInDb is null)
            return NotFound();

        var product = new ProductModel()
        {
            Id = id,
            Name = model.Name,
            InStock = model.InStock,
            CategoryId = model.Category,
            Description = model.Description,
            IsAvailable = model.IsAvailable,
            ImageUrl = model.ImageUrl,
            Price = model.Price,
            UserId = productInDb.UserId
        };

        if (product.InStock == 0)
        {
            product.IsAvailable = false;
        }
        
        var updated = await _productRepository.UpdateProduct(product);
        return updated ? Ok(product) : BadRequest(new { custom = "Something went wrong" });
    }
    
    [HttpDelete("deleteProduct/{id}")]
    public async Task<IActionResult> DeleteProduct([FromRoute] string id)
    {
        var deleted = await _productRepository.DeleteProduct(id);
        return !deleted ? NotFound() : NoContent();
    }
}