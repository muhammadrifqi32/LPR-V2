using System.ComponentModel.DataAnnotations.Schema;

namespace PurchaseRequestSystem.Models;

[Table("tbl_payment")]
public class Payment
{
    public string PaymentId { get; set; } = string.Empty;
    public string InvoiceId { get; set; } = string.Empty;
    public DateTime PaymentDate { get; set; }
    public string? PaymentReferenceNo { get; set; }
    public string StatusDetailId { get; set; } = string.Empty;
    public decimal PaidAmount { get; set; }
    public string? Notes { get; set; }
    public string? PaymentProofPath { get; set; }
    public DateTime CreatedAt { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string? UpdatedBy { get; set; }

    public Invoice Invoice { get; set; } = null!;
    public StatusDetail StatusDetail { get; set; } = null!;
}
