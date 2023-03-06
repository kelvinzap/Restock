namespace Restock.Models;

public class CartModel
{
    public string Id { get; set; }
    public List<CartItemModel> Items { get; set; }
    public decimal TotalPrice { get; set; }
    public string UserId { get; set; }

    public CartModel()
    {
        this.TotalPrice = 0.0m;
    }
}