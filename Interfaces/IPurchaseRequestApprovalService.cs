using PurchaseRequestSystem.DTOs;

namespace PurchaseRequestSystem.Interfaces;

public interface IPurchaseRequestApprovalService
{
    Task<SubmitResponseDto> SubmitAsync(string purchaseRequestId, SubmitPurchaseRequestDto? dto, CancellationToken cancellationToken = default);
    Task<SubmitResponseDto> ApproveByGmAsync(string purchaseRequestId, ApprovalActionDto dto, CancellationToken cancellationToken = default);
    Task<SubmitResponseDto> RejectByGmAsync(string purchaseRequestId, ApprovalActionDto dto, CancellationToken cancellationToken = default);
    Task<SubmitResponseDto> RequestRevisionByGmAsync(string purchaseRequestId, ApprovalActionDto dto, CancellationToken cancellationToken = default);
    Task<SubmitResponseDto> RecordChairmanApprovalAsync(string purchaseRequestId, ChairmanConfirmationDto dto, CancellationToken cancellationToken = default);
    Task<SubmitResponseDto> RecordChairmanRejectionAsync(string purchaseRequestId, ChairmanConfirmationDto dto, CancellationToken cancellationToken = default);
    Task<SubmitResponseDto> RecordChairmanRevisionAsync(string purchaseRequestId, ChairmanConfirmationDto dto, CancellationToken cancellationToken = default);
    Task<List<ApprovalHistoryResponseDto>> GetApprovalHistoryAsync(string purchaseRequestId, CancellationToken cancellationToken = default);
}
