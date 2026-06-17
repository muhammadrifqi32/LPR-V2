using System.ComponentModel.DataAnnotations.Schema;

namespace PurchaseRequestSystem.Models;

/// <summary>One PO can have many GRs (partial shipments).</summary>
[Table("tbl_goods_receipt")]
public class GoodsReceipt
{
    public string GoodsReceiptId { get; set; }
    public string GoodsReceiptNo { get; set; } = string.Empty;
    public string PurchaseOrderId { get; set; }
    public string ReceivedBy { get; set; }
    public DateTime ReceivedDate { get; set; }
    public string StatusId { get; set; }
    /// <summary>Quick flag: did anything go wrong in this shipment.</summary>
    public bool HasDiscrepancy { get; set; }
    public string? DiscrepancyNotes { get; set; }
    public string? Notes { get; set; }

    public DateTime CreatedAt { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string? UpdatedBy { get; set; }

    public PurchaseOrder PurchaseOrder { get; set; } = null!;
    public Status Status { get; set; } = null!;
    public ICollection<GoodsReceiptDetail> Details { get; set; } = new List<GoodsReceiptDetail>();
    public ICollection<PurchaseOrderPayment> Payments { get; set; } = new List<PurchaseOrderPayment>();
}
