namespace PurchaseRequestSystem.DTOs;

public class CreateProjectProcurementRequestDto
{
    public string ProposalId { get; set; }
    public string RequesterId { get; set; }
    public DateTime RequestDate { get; set; }
    public string? Notes { get; set; }
    public List<CreateProjectPurchaseRequestDetailDto> Details { get; set; } = new();
}

public class CreateProjectPurchaseRequestDetailDto
{
    public string ProposalDetailId { get; set; }
    public string MaterialId { get; set; }
    public string UomId { get; set; }
    public string? Description { get; set; }
    public decimal Quantity { get; set; }
    public string? Notes { get; set; }
}

public class CreateNonProjectProcurementRequestDto
{
    public string RequesterId { get; set; }
    public DateTime RequestDate { get; set; }
    public string? Notes { get; set; }
    public List<CreatePurchaseRequestDetailDto> Details { get; set; } = new();
}

public class CreatePurchaseRequestDetailDto
{
    public string MaterialId { get; set; }
    public string UomId { get; set; }
    public string? Description { get; set; }
    public decimal Quantity { get; set; }
    public string? Notes { get; set; }
}

public class ProcurementRequestResponseDto
{
    public string ProcurementRequestId { get; set; }
    public string ProcurementRequestNo { get; set; } = string.Empty;
    public string RequestTypeId { get; set; }
    public string RequestTypeCode { get; set; } = string.Empty;
    public string RequestTypeName { get; set; } = string.Empty;
    public string? ProposalId { get; set; }
    public string? ProposalNo { get; set; }
    public string RequesterId { get; set; }
    public DateTime RequestDate { get; set; }
    public string StatusId { get; set; }
    public string StatusName { get; set; } = string.Empty;
    public DateTime? SubmittedAt { get; set; }
    public DateTime CreatedAt { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string? UpdatedBy { get; set; }
    public PurchaseRequestResponseDto? PurchaseRequest { get; set; }
}
