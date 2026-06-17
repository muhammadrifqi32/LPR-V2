using System.ComponentModel.DataAnnotations.Schema;

namespace PurchaseRequestSystem.Models;

[Table("tbl_invoice")]
public class Invoice
{
    public string InvoiceId { get; set; } = string.Empty;
    public string PurchaseOrderId { get; set; } = string.Empty;
    public string GoodsReceiptId { get; set; } = string.Empty;
    public string InvoiceNo { get; set; } = string.Empty;
    public DateTime InvoiceDate { get; set; }
    public DateTime DueDate { get; set; }
    public decimal SubtotalAmount { get; set; }
    public decimal TaxAmount { get; set; }
    public decimal TotalAmount { get; set; }
    public string StatusDetailId { get; set; } = string.Empty;
    public string? Notes { get; set; }
    public string? InvoiceProofPath { get; set; }
    public DateTime CreatedAt { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string? UpdatedBy { get; set; }

    public PurchaseOrder PurchaseOrder { get; set; } = null!;
    public GoodsReceipt GoodsReceipt { get; set; } = null!;
    public StatusDetail StatusDetail { get; set; } = null!;
    public ICollection<Payment> Payments { get; set; } = new List<Payment>();
}
