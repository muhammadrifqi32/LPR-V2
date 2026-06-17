using PurchaseRequestSystem.DTOs;

namespace PurchaseRequestSystem.Interfaces;

public interface IApprovalStageService
{
    Task<IReadOnlyList<ApprovalStageResponseDto>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<ApprovalStageResponseDto> GetByIdAsync(string id, CancellationToken cancellationToken = default);
    Task<ApprovalStageResponseDto> CreateAsync(CreateApprovalStageDto dto, CancellationToken cancellationToken = default);
    Task<ApprovalStageResponseDto> UpdateAsync(string id, UpdateApprovalStageDto dto, CancellationToken cancellationToken = default);
    Task DeleteAsync(string id, CancellationToken cancellationToken = default);
}
