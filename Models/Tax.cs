using System.ComponentModel.DataAnnotations.Schema;

namespace PurchaseRequestSystem.Models;

[Table("tbl_tax")]
public class Tax
{
    public string TaxId { get; set; } = string.Empty;
    public string TaxCode { get; set; } = string.Empty;
    public string TaxName { get; set; } = string.Empty;
    public decimal TaxRate { get; set; }
    public string? TaxDescription { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    public ICollection<PurchaseOrder> PurchaseOrders { get; set; } = new List<PurchaseOrder>();
}
