using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Restock.Models;

public class ProductModel
{
    [Key]
    public string Id { get; set; }
    public string Name { get; set; }
    public int InStock { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string UserId { get; set; }
    [ForeignKey(nameof(UserId))]
    public UserModel User { get; set; }
    public string Description { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal Price { get; set; }
    public string ImageUrl { get; set; }
    public string CategoryId { get; set; }
    [ForeignKey(nameof(CategoryId))]
    public CategoryModel Category { get; set; }
    
    public bool IsAvailable { get; set; }
}