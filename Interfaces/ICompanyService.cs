using PurchaseRequestSystem.DTOs;

namespace PurchaseRequestSystem.Interfaces;

public interface ICompanyService
{
    Task<IReadOnlyList<CompanyResponseDto>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<CompanyResponseDto> GetByIdAsync(string id, CancellationToken cancellationToken = default);
    Task<CompanyResponseDto> CreateAsync(CreateCompanyDto dto, CancellationToken cancellationToken = default);
    Task<CompanyResponseDto> UpdateAsync(string id, UpdateCompanyDto dto, CancellationToken cancellationToken = default);
    Task DeleteAsync(string id, CancellationToken cancellationToken = default);
}
