using PurchaseRequestSystem.DTOs;

namespace PurchaseRequestSystem.Interfaces;

public interface IPurchaseRequestService
{
    Task<PurchaseRequestResponseDto> GetByIdAsync(string id, CancellationToken cancellationToken = default);
    Task<SubmitResponseDto> SubmitAsync(string id, CancellationToken cancellationToken = default);
}
