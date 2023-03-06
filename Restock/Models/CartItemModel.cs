namespace Restock.Models;

public class CartItemModel
{
    public string CartId { get; set; }
    public string ProductId { get; set; }
    public int Quantity { get; set; }
}