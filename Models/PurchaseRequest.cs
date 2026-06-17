using System.ComponentModel.DataAnnotations.Schema;

namespace PurchaseRequestSystem.Models;

/// <summary>One-to-one with ProcurementRequest. Approved via GM + Chairman stages.</summary>
[Table("tbl_purchase_request")]
public class PurchaseRequest
{
    public string PurchaseRequestId { get; set; }
    public string? PurchaseRequestNo { get; set; }
    public string ProcurementRequestId { get; set; }
    public string StatusId { get; set; }
    public string? Notes { get; set; }

    public DateTime CreatedAt { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string? UpdatedBy { get; set; }

    public ProcurementRequest ProcurementRequest { get; set; } = null!;
    public Status Status { get; set; } = null!;
    public ICollection<PurchaseOrder> PurchaseOrders { get; set; } = new List<PurchaseOrder>();
    public ICollection<PurchaseRequestDetail> Details { get; set; } = new List<PurchaseRequestDetail>();
}
