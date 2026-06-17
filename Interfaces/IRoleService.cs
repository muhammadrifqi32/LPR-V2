using PurchaseRequestSystem.DTOs;

namespace PurchaseRequestSystem.Interfaces;

public interface IRoleService
{
    Task<IReadOnlyList<RoleResponseDto>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<RoleResponseDto> GetByIdAsync(string id, CancellationToken cancellationToken = default);
    Task<RoleResponseDto> CreateAsync(CreateRoleDto dto, CancellationToken cancellationToken = default);
    Task<RoleResponseDto> UpdateAsync(string id, UpdateRoleDto dto, CancellationToken cancellationToken = default);
    Task DeleteAsync(string id, CancellationToken cancellationToken = default);
}
