using Restock.Contracts.v1.Request;
using Restock.Models;

namespace Restock.Services;

public interface ICartService
{
    CartModel GetCart(string id);
   
    void AddToCart(AddToCartRequest request);
    void RemoveFromCart(string cartid, string productId);

}