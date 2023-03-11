using Restock.Contracts.v1.Request;
using Restock.Models;

namespace Restock.Services;

public interface ICartService
{
    Task<CartModel> GetCart(string id = null);
   
    Task AddToCart(UpdateQuantityInCartRequest request);
    Task ReduceQuantityInCart(UpdateQuantityInCartRequest request);
    Task RemoveFromCart(string cartId, string productId);

}