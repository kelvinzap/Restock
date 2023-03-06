using Restock.Models;

namespace Restock.Repositories;

public class CartRepository : ICartRepository
{
    private readonly Dictionary<string, CartModel> _carts = new();

    public bool CreateCart(CartModel model)
    {
        if (model is null)
            return false;
        
        _carts.Add(model.Id, model);
        return true;
    }

    public bool UpdateCart(CartModel model)
    {
        if (model is null)
            return false;

        _carts[model.Id] = model;
        return true;
    }

    public CartModel GetCart(string Id)
    {
        var exists = _carts.TryGetValue(Id, out var model);
        return exists ? model : null;
    }

    public bool DeleteCart(string Id)
    {
        var cart = GetCart(Id);

        if (cart is null)
            return false;
        
        _carts.Remove(Id);
        return true;
    }
}