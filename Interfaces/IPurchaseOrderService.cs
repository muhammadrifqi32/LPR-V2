using PurchaseRequestSystem.DTOs;

namespace PurchaseRequestSystem.Interfaces;

public interface IPurchaseOrderService
{
    Task<List<PurchaseOrderResponseDto>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<PurchaseOrderResponseDto> GetByIdAsync(string id, CancellationToken cancellationToken = default);
    Task<PurchaseOrderResponseDto> GetByPurchaseRequestIdAsync(string purchaseRequestId, CancellationToken cancellationToken = default);
    Task<PurchaseOrderResponseDto> GenerateFromPurchaseRequestAsync(string purchaseRequestId, GeneratePurchaseOrderDto dto, CancellationToken cancellationToken = default);
    Task<PurchaseOrderResponseDto> UpdateAsync(string id, UpdatePurchaseOrderDto dto, CancellationToken cancellationToken = default);
    Task DeleteAsync(string id, CancellationToken cancellationToken = default);
}
