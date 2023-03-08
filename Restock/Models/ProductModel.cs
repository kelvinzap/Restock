using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Restock.Models;

public class ProductModel
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public string Name { get; set; }
    public int InStock { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string UserId { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string ImageUrl { get; set; }
    public string Category { get; set; }
    public List<BasicReviewModel> Reviews { get; set; } = new();
    public bool IsAvailable { get; set; }
}