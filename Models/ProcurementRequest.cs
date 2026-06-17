using System.ComponentModel.DataAnnotations.Schema;

namespace PurchaseRequestSystem.Models;

/// <summary>
/// Entry point for ALL requests.
/// PROJECT: ProposalId filled (PR created after proposal approved).
/// NON-PROJECT: ProposalId null (PR created directly by Procure).
/// </summary>
[Table("tbl_procurement_request")]
public class ProcurementRequest
{
    public string ProcurementRequestId { get; set; }
    public string ProcurementRequestNo { get; set; } = string.Empty;
    public string RequestTypeId { get; set; }
    public string? ProposalId { get; set; }
    public string RequesterId { get; set; }
    public DateTime RequestDate { get; set; }
    public string StatusId { get; set; }
    public DateTime? SubmittedAt { get; set; }

    public DateTime CreatedAt { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string? UpdatedBy { get; set; }

    public RequestType RequestType { get; set; } = null!;
    public Proposal? Proposal { get; set; }
    public Status Status { get; set; } = null!;
    public PurchaseRequest? PurchaseRequest { get; set; }
    public ICollection<ApprovalRecord> ApprovalRecords { get; set; } = new List<ApprovalRecord>();
}
