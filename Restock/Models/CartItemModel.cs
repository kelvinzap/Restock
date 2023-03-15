using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restock.Models;

public class CartItemModel
{
    [Key]
    public string Id { get; set; }
    public string CartId { get; set; }
    [ForeignKey(nameof(CartId))]
    public CartModel Cart { get; set; }
    public string ProductId { get; set; }
    [Column(TypeName = "decimal(18,2)")]

    public decimal Price { get; set; }

    public int Quantity { get; set; }
}