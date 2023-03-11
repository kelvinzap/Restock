using MongoDB.Driver;
using Restock.Data;
using Restock.Models;

namespace Restock.Repositories;

public class MongoCartRepository : ICartRepository
{
    private readonly IMongoCollection<CartModel> _carts;

    public MongoCartRepository(IDbConnection db)
    {
        _carts = db.CartCollection;
    }

    public async Task<CartModel> CreateCart(CartModel model)
    {
        if (model is null)
            return null;

       await  _carts.InsertOneAsync(model);
        return model;
    }

    public bool UpdateCart(CartModel model)
    {
        throw new NotImplementedException();
    }

    public async Task<CartModel> GetCart(string Id)
    {
        var results = await _carts.FindAsync(x => x.Id == Id);
        return results.SingleOrDefault();
    }

    public bool DeleteCart(string Id)
    {
        throw new NotImplementedException();
    }
}