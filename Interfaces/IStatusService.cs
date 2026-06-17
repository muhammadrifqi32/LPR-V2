using PurchaseRequestSystem.DTOs;

namespace PurchaseRequestSystem.Interfaces;

public interface IStatusService
{
    Task<IReadOnlyList<StatusResponseDto>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<StatusResponseDto> GetByIdAsync(string id, CancellationToken cancellationToken = default);
    Task<StatusResponseDto> CreateAsync(CreateStatusDto dto, CancellationToken cancellationToken = default);
    Task<StatusResponseDto> UpdateAsync(string id, UpdateStatusDto dto, CancellationToken cancellationToken = default);
    Task DeleteAsync(string id, CancellationToken cancellationToken = default);
}
