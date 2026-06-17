using PurchaseRequestSystem.DTOs;

namespace PurchaseRequestSystem.Interfaces;

public interface IVendorService
{
    Task<IReadOnlyList<VendorResponseDto>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<VendorResponseDto> GetByIdAsync(string id, CancellationToken cancellationToken = default);
    Task<VendorResponseDto> CreateAsync(CreateVendorDto dto, CancellationToken cancellationToken = default);
    Task<VendorResponseDto> UpdateAsync(string id, UpdateVendorDto dto, CancellationToken cancellationToken = default);
    Task DeleteAsync(string id, CancellationToken cancellationToken = default);
}
