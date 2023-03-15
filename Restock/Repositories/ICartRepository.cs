using Restock.Models;

namespace Restock.Repositories;

public interface ICartRepository
{
    Task<bool> CreateCart(CartModel model);
    Task<bool> UpdateCart(CartModel model);
    Task<CartModel?> GetCartById(string Id);
    Task<bool> DeleteCart(string Id);
    Task<bool> DeleteCartItem(string Id);
}