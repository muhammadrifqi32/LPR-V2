namespace PurchaseRequestSystem.DTOs;

public class PurchaseRequestResponseDto
{
    public string PurchaseRequestId { get; set; }
    public string PurchaseRequestNo { get; set; } = string.Empty;
    public string ProcurementRequestId { get; set; }
    public string? ProcurementRequestNo { get; set; }
    public string StatusId { get; set; }
    public string StatusName { get; set; } = string.Empty;
    public string? Notes { get; set; }
    public DateTime CreatedAt { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string? UpdatedBy { get; set; }
    public List<PurchaseRequestDetailResponseDto> Details { get; set; } = new();
}

public class PurchaseRequestDetailResponseDto
{
    public string PurchaseRequestDetailId { get; set; }
    public string PurchaseRequestId { get; set; }
    public string? ProposalDetailId { get; set; }
    public string MaterialId { get; set; }
    public string? MaterialCode { get; set; }
    public string? MaterialName { get; set; }
    public string UomId { get; set; }
    public string? UomCode { get; set; }
    public string? UomName { get; set; }
    public string? Description { get; set; }
    public decimal Quantity { get; set; }
    public string? Notes { get; set; }
    public DateTime CreatedAt { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string? UpdatedBy { get; set; }
}
