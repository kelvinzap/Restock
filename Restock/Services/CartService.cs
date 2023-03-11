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

    public async Task<CartModel> GetCart(string id = null)
    {
        if (string.IsNullOrWhiteSpace(id))
        {
            CartModel newCart = new()
            {
                
                Items = new List<CartItemModel>()
            };
            var result = await _cartRepository.CreateCart(newCart);
            return result;
        }
        
        var cart = _cartRepository.GetCart(id);

        if (cart is null)
        {
            CartModel newCart = new()
            {
                
                Items = new List<CartItemModel>()
            };
            _cartRepository.CreateCart(newCart);
            
            return newCart;
        }

        return await cart;
    }

    public async Task AddToCart(UpdateQuantityInCartRequest request)
    {
        var product = _productRepository.GetProduct(request.ProductId);
        var cart = await _cartRepository.GetCart(request.CartId);
        
        if(cart is null)
            return;
        
        if(product is null)
            return;

        var cartItem = cart.Items.SingleOrDefault(x => x.ProductId == product.Id);
        
        if (cartItem is null)
        {
            cartItem = new CartItemModel()
            {
                CartId = cart.Id,
                ProductId = product.Id,
                Quantity = 1
            };
            
            cart.Items.Add(cartItem);
            return;
        }

        cart.Items.Single(x => x.ProductId == product.Id).Quantity += 1;

        _cartRepository.UpdateCart(cart);
    }
    
    
    public async Task ReduceQuantityInCart(UpdateQuantityInCartRequest request)
    {
        var product = _productRepository.GetProduct(request.ProductId);
        var cart = await _cartRepository.GetCart(request.CartId);
        
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
        _cartRepository.UpdateCart(cart);
    }

    public async Task RemoveFromCart(string cartId, string productId)
    {
        var product = _productRepository.GetProduct(productId);
        var cart = await _cartRepository.GetCart(cartId);
        
        if(cart is null)
            return;
        
        if(product is null)
            return;
        
        var cartItem = cart.Items.SingleOrDefault(x => x.ProductId == product.Id);
        cart.Items.Remove(cartItem);
        _cartRepository.UpdateCart(cart);
        
    }
}