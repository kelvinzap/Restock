using Restock.Contracts.v1.Request;
using Restock.Models;
using Restock.Repositories;

namespace Restock.Services;

public class CartService : ICartService
{
    private readonly ICartRepository _cartRepository;
    private readonly IProductRepository _productRepository;

    public CartService(ICartRepository cartRepository, IProductRepository productRepository)
    {
        _cartRepository = cartRepository;
        _productRepository = productRepository;
    }

    public async Task<CartModel?> GetCart(string? id = null)
    {
        if (string.IsNullOrWhiteSpace(id))
        {
            CartModel newCart = new()
            {
                Id = Guid.NewGuid().ToString(),
                Items = new List<CartItemModel>()    
            };

            await _cartRepository.CreateCart(newCart);
            return newCart;
        }
        
        var cart = await _cartRepository.GetCartById(id);

        return cart is null ? null : cart;
    }

    public async Task AddToCart(UpdateQuantityInCartRequest request)
    {
        var product = await _productRepository.GetProductById(request.ProductId);
        var cart = await _cartRepository.GetCartById(request.CartId);
        
        if(cart is null)
            return;
        
        if(product is null)
            return;

        var cartItem = cart.Items.SingleOrDefault(x => x.ProductId == product.Id);
        
        if (cartItem is null)
        {
            cartItem = new CartItemModel()
            {
                Id = Guid.NewGuid().ToString(),
                CartId = cart.Id,
                ProductId = product.Id,
                Quantity = 1
            };
            
            cart.Items.Add(cartItem);
            await _cartRepository.UpdateCart(cart);
            return;
        }

        cart.Items.Single(x => x.ProductId == product.Id).Quantity += 1;
        await _cartRepository.UpdateCart(cart);
    }
    
    
    public async Task ReduceQuantityInCart(UpdateQuantityInCartRequest request)
    {
        var product = await _productRepository.GetProductById(request.ProductId);
        var cart = await _cartRepository.GetCartById(request.CartId);
        
        if(cart is null)
            return;
        
        if(product is null)
            return;
        
        var cartItem = cart.Items.SingleOrDefault(x => x.ProductId == product.Id);
        
        if (cartItem is null)
            return;

        if (cartItem.Quantity <= 1)
            return;
        
        cart.Items.Single(x => x.ProductId == product.Id).Quantity -= 1;
        await _cartRepository.UpdateCart(cart);
    }

    public async Task RemoveFromCart(string cartId, string productId)
    {
        var product = await _productRepository.GetProductById(productId);
        var cart = await _cartRepository.GetCartById(cartId);
        
        if(cart is null)
            return;
        
        if(product is null)
            return;
        
        var cartItem = cart.Items.SingleOrDefault(x => x.ProductId == product.Id);

        if (cartItem is null)
            return;

        cart.Items.Remove(cartItem);
        await _cartRepository.UpdateCart(cart);
        //await _cartRepository.DeleteCartItem(cartItem.Id);
        
    }
}