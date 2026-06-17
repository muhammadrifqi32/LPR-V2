using PurchaseRequestSystem.Models;

namespace PurchaseRequestSystem.Interfaces;

public interface IStatusLookupService
{
    Task<Status> GetRequiredAsync(string statusName, CancellationToken cancellationToken = default);
    Task<Status> GetFirstExistingAsync(IEnumerable<string> statusNames, CancellationToken cancellationToken = default);
    Task<bool> IsAnyAsync(string statusId, IEnumerable<string> statusNames, CancellationToken cancellationToken = default);
    Task<string?> GetNameAsync(string statusId, CancellationToken cancellationToken = default);
}
