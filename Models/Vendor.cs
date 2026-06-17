using System.ComponentModel.DataAnnotations.Schema;

namespace PurchaseRequestSystem.Models;

[Table("tbl_vendor")]
public class Vendor
{
    public string VendorId { get; set; }
    public string VendorCode { get; set; } = string.Empty;
    public string VendorName { get; set; } = string.Empty;
    public bool IsDeleted { get; set; }

    public DateTime CreatedAt { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string? UpdatedBy { get; set; }

    public ICollection<PurchaseOrder> PurchaseOrders { get; set; } = new List<PurchaseOrder>();
}
