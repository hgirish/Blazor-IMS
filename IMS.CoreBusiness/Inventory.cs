using System.ComponentModel.DataAnnotations;

namespace IMS.CoreBusiness;
public class Inventory
{
    public int InventoryId { get; set; }
    [Required]
    public string InventoryName { get; set; } = string.Empty;
    [Range(0, int.MaxValue, ErrorMessage = "Quantity must be greater or equal zero")]
    public int Quantity { get; set; }
    [Range(0, int.MaxValue, ErrorMessage ="Price must be greater than zero")]
    public double Price { get; set; }
}
