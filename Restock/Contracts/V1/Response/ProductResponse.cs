namespace Restock.Contracts.v1.Response;

public class ProductResponse
{
    public string Id { get; set; }
    public string Name { get; set; }
    public int InStock { get; set; }
    public DateTime CreatedAt { get; set; }
    
    public string UserId { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string ImageUrl { get; set; }
    public string Category { get; set; }
    public bool IsAvailable { get; set; }
}