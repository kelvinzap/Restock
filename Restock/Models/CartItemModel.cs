namespace Restock.Models;

public class CartItemModel
{
    public string Id { get; set; }
    public string CartId { get; set; }
    public string ProductId { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
}