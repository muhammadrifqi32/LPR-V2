namespace PurchaseRequestSystem.DTOs;

public class CreateProposalDto
{
    public string RequesterId { get; set; }
    public DateTime ProposalDate { get; set; }
    public string? Purpose { get; set; }
    public string? ProposalAttachmentPath { get; set; }
    public List<CreateProposalDetailDto> Details { get; set; } = new();
}

public class CreateProposalDetailDto
{
    public string MaterialId { get; set; }
    public string UomId { get; set; }
    public string? Description { get; set; }
    public decimal RequestedQty { get; set; }
}

public class UpdateProposalDto
{
    public string RequesterId { get; set; }
    public DateTime ProposalDate { get; set; }
    public string? Purpose { get; set; }
    public string? ProposalAttachmentPath { get; set; }
    public List<UpdateProposalDetailDto> Details { get; set; } = new();
}

public class UpdateProposalDetailDto
{
    public string? ProposalDetailId { get; set; }
    public string MaterialId { get; set; }
    public string UomId { get; set; }
    public string? Description { get; set; }
    public decimal RequestedQty { get; set; }
}

public class ReviewProposalDto
{
    public string? Status { get; set; }
    public string? Notes { get; set; }
    public string? ReviewedBy { get; set; }
    public List<ReviewProposalDetailDto> Details { get; set; } = new();
}

public class ReviewProposalDetailDto
{
    public string ProposalDetailId { get; set; }
    public decimal ApprovedQty { get; set; }
    public string? Status { get; set; }
}

public class ProposalResponseDto
{
    public string ProposalId { get; set; }
    public string ProposalNo { get; set; } = string.Empty;
    public string RequesterId { get; set; }
    public DateTime ProposalDate { get; set; }
    public string? Purpose { get; set; }
    public string StatusId { get; set; }
    public string StatusName { get; set; } = string.Empty;
    public string? ProposalAttachmentPath { get; set; }
    public DateTime? SubmittedAt { get; set; }
    public DateTime CreatedAt { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string? UpdatedBy { get; set; }
    public List<ProposalDetailResponseDto> Details { get; set; } = new();
}

public class ProposalDetailResponseDto
{
    public string ProposalDetailId { get; set; }
    public string ProposalId { get; set; }
    public string MaterialId { get; set; }
    public string? MaterialCode { get; set; }
    public string? MaterialName { get; set; }
    public string UomId { get; set; }
    public string? UomCode { get; set; }
    public string? UomName { get; set; }
    public string? Description { get; set; }
    public decimal RequestedQty { get; set; }
    public decimal ApprovedQty { get; set; }
    public decimal RemainingQty { get; set; }
    public string? StatusId { get; set; }
    public string? StatusName { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}

public class SubmitResponseDto
{
    public string Id { get; set; }
    public string DocumentNo { get; set; } = string.Empty;
    public string StatusId { get; set; }
    public string StatusName { get; set; } = string.Empty;
    public DateTime? SubmittedAt { get; set; }
}
