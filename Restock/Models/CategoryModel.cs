using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Restock.Models;

public class CategoryModel
{
    [Key]
    public string Id { get; set; }
    public string Name { get; set; }
}