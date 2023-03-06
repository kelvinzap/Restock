namespace Restock.Contracts.v1.Request;

public class AddToCartRequest
{
    public string CartId { get; set; }
    public string ProductId { get; set; }
}