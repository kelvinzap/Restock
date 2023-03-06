namespace Restock.Contracts.v1.Request;

public class UpdateProductRequest
{
    public string Name { get; set; }
    public int InStock { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string ImageUrl { get; set; }
    public string Category { get; set; }
    public bool IsAvailable { get; set; } 
}