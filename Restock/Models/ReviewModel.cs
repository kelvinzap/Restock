using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Restock.Models;

public class ReviewModel
{
   [Key]
    public string Id { get; set; } 
    public string ProductId { get; set; }
    [ForeignKey(nameof(ProductId))]
    public ProductModel Product { get; set; }
    public string AuthorName { get; set; }
    public string Title { get; set; } 
    public string Body { get; set; } 
    public int Rating { get; set; } 
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    
}