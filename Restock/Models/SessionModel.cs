using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Restock.Models;

public class SessionModel
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    public string UserId { get; set; }

    public DateTime CreatedAt { get; set; }
}