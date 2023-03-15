using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restock.Contracts.v1.Request;
using Restock.Repositories;
using Restock.Services;

namespace Restock.Controllers;

[ApiController]
[Route("api/carts/")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

public class CartController : ControllerBase
{
    private readonly IProductRepository _productRepository;
    private readonly ICartService _cartService;

    public CartController(IProductRepository productRepository, ICartService cartService)
    {
        _productRepository = productRepository;
        _cartService = cartService;
    }

    [HttpGet("getCart")]
    public async Task<IActionResult> GetCart([FromQuery] string? cartId)
    {
        if (string.IsNullOrWhiteSpace(cartId))
        {
            var newCart = await _cartService.GetCart();
            return Ok(newCart);
        }

        var cart = await _cartService.GetCart(cartId);
        
        if (cart is null)
            return BadRequest();
        
        cart.Items = cart.Items.Where(x => x.Quantity > 0).ToList();
        
        return Ok(cart);
    }

    [HttpPost("addToCart")]
    public async Task<IActionResult> AddToCart([FromBody] UpdateQuantityInCartRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.ProductId))
            return BadRequest();

        if (string.IsNullOrWhiteSpace(request.CartId))
            return BadRequest();
        
       await  _cartService.AddToCart(request);
        return Ok("It worked");
    }

    [HttpPost("reduceQuantity")]
    public async Task<IActionResult> ReduceQuantity([FromBody] UpdateQuantityInCartRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.ProductId))
            return BadRequest();

        if (string.IsNullOrWhiteSpace(request.CartId))
            return BadRequest(); 
        
        
        await _cartService.ReduceQuantityInCart(request);
        return Ok();
    }

    [HttpDelete("removeFromCart/{cartId}/{productId}")]
    public async Task<IActionResult> RemoveFromCart([FromRoute] string cartId, [FromRoute] string productId)
    {
        if (string.IsNullOrWhiteSpace(productId))
            return BadRequest();

        if (string.IsNullOrWhiteSpace(cartId))
            return BadRequest();

        await _cartService.RemoveFromCart(cartId, productId);
        return Ok();
    }
}