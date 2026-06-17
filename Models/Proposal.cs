using System.ComponentModel.DataAnnotations.Schema;

namespace PurchaseRequestSystem.Models;

/// <summary>PROJECT flow only. Reviewed by Procure (status change + activity log).</summary>
[Table("tbl_proposal")]
public class Proposal
{
    public string ProposalId { get; set; }
    public string ProposalNo { get; set; } = string.Empty;
    public string RequesterId { get; set; }
    public DateTime ProposalDate { get; set; }
    public string? Purpose { get; set; }
    public string StatusId { get; set; }
    public string? ProposalAttachmentPath { get; set; }
    public DateTime? SubmittedAt { get; set; }

    public DateTime CreatedAt { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string? UpdatedBy { get; set; }

    public Status Status { get; set; } = null!;
    public ICollection<ProposalDetail> Details { get; set; } = new List<ProposalDetail>();
    public ICollection<ProcurementRequest> ProcurementRequests { get; set; } = new List<ProcurementRequest>();
}
