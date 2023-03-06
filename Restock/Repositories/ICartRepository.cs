using Restock.Models;

namespace Restock.Repositories;

public interface ICartRepository
{
    bool CreateCart(CartModel model);
    bool UpdateCart(CartModel model);
    CartModel GetCart(string Id);
    bool DeleteCart(string Id);
}