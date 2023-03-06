namespace Restock.Contracts.v1.Request;

public class UpdateQuantityInCartRequest
{
    public string CartId { get; set; }
    public string ProductId { get; set; }
}