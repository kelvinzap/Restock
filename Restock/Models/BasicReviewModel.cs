using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Restock.Models;

public class BasicReviewModel
{
    [BsonRepresentation(BsonType.ObjectId)]
    public int Id { get; set; }
    public string AuthorName { get; set; }
    public string Title { get; set; }
    public int Rating { get; set; } 
    public DateTime CreatedAt { get; set; }
}