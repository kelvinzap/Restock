using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Restock.Models;

public class UserModel
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public string  FirstName { get; set; }
    public string  MiddleName { get; set; }
    public string  LastName { get; set; }
    public string Email { get; set; }
}