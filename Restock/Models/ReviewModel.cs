namespace Restock.Models;

public class ReviewModel
{
    public int Id { get; set; } 
    public int ProductId { get; set; } 
    public string AuthorName { get; set; }
    public string Title { get; set; } 
    public string Body { get; set; } 
    public int Rating { get; set; } 
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}