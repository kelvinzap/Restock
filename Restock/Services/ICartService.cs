using Restock.Contracts.v1.Request;
using Restock.Models;

namespace Restock.Services;

public interface ICartService
{
    CartModel GetCart(string id = null);
   
    void AddToCart(UpdateQuantityInCartRequest request);
    void ReduceQuantityInCart(UpdateQuantityInCartRequest request);
    void RemoveFromCart(string cartId, string productId);

}