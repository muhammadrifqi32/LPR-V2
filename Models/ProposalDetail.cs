using System.ComponentModel.DataAnnotations.Schema;

namespace PurchaseRequestSystem.Models;

[Table("tbl_proposal_detail")]
public class ProposalDetail
{
    public string ProposalDetailId { get; set; }
    public string ProposalId { get; set; }
    public string MaterialId { get; set; }
    public string UomId { get; set; }
    public string? Description { get; set; }
    public decimal RequestedQty { get; set; }
    /// <summary>Set by Procure during review. Drives the remaining-qty business rule for PRs.</summary>
    public decimal ApprovedQty { get; set; }
    public string? StatusId { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    public Proposal Proposal { get; set; } = null!;
    public Material Material { get; set; } = null!;
    public Uom Uom { get; set; } = null!;
    public Status? Status { get; set; }
}
