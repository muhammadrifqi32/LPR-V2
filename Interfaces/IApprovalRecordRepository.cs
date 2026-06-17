using PurchaseRequestSystem.Models;

namespace PurchaseRequestSystem.Interfaces;

public interface IApprovalRecordRepository
{
    IQueryable<ApprovalRecord> Query();
    Task<ApprovalRecord?> GetByProcurementRequestAndStageAsync(string procurementRequestId, string stageName, CancellationToken cancellationToken = default);
    Task<List<ApprovalRecord>> GetByProcurementRequestIdAsync(string procurementRequestId, CancellationToken cancellationToken = default);
    Task AddAsync(ApprovalRecord entity, CancellationToken cancellationToken = default);
    Task UpdateAsync(ApprovalRecord entity, CancellationToken cancellationToken = default);
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
