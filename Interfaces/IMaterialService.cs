using PurchaseRequestSystem.DTOs;

namespace PurchaseRequestSystem.Interfaces;

public interface IMaterialService
{
    Task<IReadOnlyList<MaterialResponseDto>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<MaterialResponseDto> GetByIdAsync(string id, CancellationToken cancellationToken = default);
    Task<MaterialResponseDto> CreateAsync(CreateMaterialDto dto, CancellationToken cancellationToken = default);
    Task<MaterialResponseDto> UpdateAsync(string id, UpdateMaterialDto dto, CancellationToken cancellationToken = default);
    Task DeleteAsync(string id, CancellationToken cancellationToken = default);
}
