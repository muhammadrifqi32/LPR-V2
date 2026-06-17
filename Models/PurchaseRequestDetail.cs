using System.ComponentModel.DataAnnotations.Schema;

namespace PurchaseRequestSystem.Models;

[Table("tbl_purchase_request_detail")]
public class PurchaseRequestDetail
{
    public string PurchaseRequestDetailId { get; set; }
    public string PurchaseRequestId { get; set; }
    /// <summary>Filled for PROJECT flow to enforce approved Proposal Detail remaining quantity.</summary>
    public string? ProposalDetailId { get; set; }
    public string MaterialId { get; set; }
    public string UomId { get; set; }
    public string? Description { get; set; }
    public decimal Quantity { get; set; }
    public string? Notes { get; set; }

    public DateTime CreatedAt { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string? UpdatedBy { get; set; }

    public PurchaseRequest PurchaseRequest { get; set; } = null!;
    public ProposalDetail? ProposalDetail { get; set; }
    public Material Material { get; set; } = null!;
    public Uom Uom { get; set; } = null!;
}
