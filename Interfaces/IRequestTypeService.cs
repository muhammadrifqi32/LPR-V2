using PurchaseRequestSystem.DTOs;

namespace PurchaseRequestSystem.Interfaces;

public interface IRequestTypeService
{
    Task<IReadOnlyList<RequestTypeResponseDto>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<RequestTypeResponseDto> GetByIdAsync(string id, CancellationToken cancellationToken = default);
    Task<RequestTypeResponseDto> CreateAsync(CreateRequestTypeDto dto, CancellationToken cancellationToken = default);
    Task<RequestTypeResponseDto> UpdateAsync(string id, UpdateRequestTypeDto dto, CancellationToken cancellationToken = default);
    Task DeleteAsync(string id, CancellationToken cancellationToken = default);
}
