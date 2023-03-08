using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Restock.Models;

public class CartModel
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public List<CartItemModel> Items { get; set; }
    public decimal TotalPrice { get; set; }
    public string UserId { get; set; }
    public string SessionId { get; set; }

    public CartModel()
    {
        this.TotalPrice = 0.0m;
    }
}