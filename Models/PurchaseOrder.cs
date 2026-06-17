using System.ComponentModel.DataAnnotations.Schema;

namespace PurchaseRequestSystem.Models;

/// <summary>One-to-one with PurchaseRequest. Created after PR is fully approved (GM + Chairman).</summary>
[Table("tbl_purchase_order")]
public class PurchaseOrder
{
    public string PurchaseOrderId { get; set; }
    public string PurchaseRequestId { get; set; }
    public string PurchaseOrderNo { get; set; } = string.Empty;
    public string? VendorId { get; set; }
    public string? CompanyId { get; set; }
    public string? TaxId { get; set; }
    public DateTime PoDate { get; set; }
    public string StatusId { get; set; }
    public string? Notes { get; set; }

    /// <summary>SUM of line subtotals before tax.</summary>
    public decimal SubtotalAmount { get; set; }
    /// <summary>e.g. 0.11 for PPN 11%.</summary>
    public decimal TaxRate { get; set; }
    /// <summary>Stored: SubtotalAmount * TaxRate.</summary>
    public decimal TaxAmount { get; set; }
    /// <summary>Stored: SubtotalAmount + TaxAmount. Final invoice amount.</summary>
    public decimal GrandtotalAmount { get; set; }
    public string? PurchaseOrderAttachmentPath { get; set; }

    public DateTime CreatedAt { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string? UpdatedBy { get; set; }

    public PurchaseRequest PurchaseRequest { get; set; } = null!;
    public Vendor? Vendor { get; set; }
    public Company? Company { get; set; }
    public Tax? Tax { get; set; }
    public Status Status { get; set; } = null!;
    public ICollection<PurchaseOrderDetail> Details { get; set; } = new List<PurchaseOrderDetail>();
    public ICollection<GoodsReceipt> GoodsReceipts { get; set; } = new List<GoodsReceipt>();
    public ICollection<PurchaseOrderPayment> Payments { get; set; } = new List<PurchaseOrderPayment>();
}
