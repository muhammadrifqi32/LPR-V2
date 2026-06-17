using PurchaseRequestSystem.DTOs;

namespace PurchaseRequestSystem.Interfaces;

public interface IUomService
{
    Task<IReadOnlyList<UomResponseDto>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<UomResponseDto> GetByIdAsync(string id, CancellationToken cancellationToken = default);
    Task<UomResponseDto> CreateAsync(CreateUomDto dto, CancellationToken cancellationToken = default);
    Task<UomResponseDto> UpdateAsync(string id, UpdateUomDto dto, CancellationToken cancellationToken = default);
    Task DeleteAsync(string id, CancellationToken cancellationToken = default);
}
