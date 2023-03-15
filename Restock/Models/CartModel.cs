using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Restock.Models;

public class CartModel
{
    [Key]
    public string Id { get; set; }
    public ICollection<CartItemModel> Items { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal TotalPrice { get; set; }
    public string? UserId { get; set; }
    public string? SessionId { get; set; }

    public CartModel()
    {
        TotalPrice = 0.0m;
    }
}