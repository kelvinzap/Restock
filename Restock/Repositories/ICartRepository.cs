using Restock.Models;

namespace Restock.Repositories;

public interface ICartRepository
{
    Task<CartModel> CreateCart(CartModel model);
    bool UpdateCart(CartModel model);
    Task<CartModel> GetCart(string Id);
    bool DeleteCart(string Id);
}