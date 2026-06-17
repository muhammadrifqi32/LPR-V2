namespace PurchaseRequestSystem.DTOs;

public class SubmitPurchaseRequestDto
{
    public string SubmittedBy { get; set; }
    public string? Notes { get; set; }
}

public class ApprovalActionDto
{
    public string ActionBy { get; set; }
    public string? Notes { get; set; }
}

public class ChairmanConfirmationDto
{
    public string RecordedBy { get; set; }
    public string Notes { get; set; } = string.Empty;
}

public class ApprovalHistoryResponseDto
{
    public string ApprovalRecordId { get; set; }
    public string ProcurementRequestId { get; set; }
    public string ApprovalStage { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public string? Notes { get; set; }
    public DateTime CreatedAt { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string? UpdatedBy { get; set; }
}
