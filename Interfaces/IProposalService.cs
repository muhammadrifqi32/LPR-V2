using PurchaseRequestSystem.DTOs;

namespace PurchaseRequestSystem.Interfaces;

public interface IProposalService
{
    Task<IReadOnlyList<ProposalResponseDto>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<ProposalResponseDto> GetByIdAsync(string id, CancellationToken cancellationToken = default);
    Task<ProposalResponseDto> CreateAsync(CreateProposalDto dto, CancellationToken cancellationToken = default);
    Task<ProposalResponseDto> UpdateAsync(string id, UpdateProposalDto dto, CancellationToken cancellationToken = default);
    Task DeleteAsync(string id, CancellationToken cancellationToken = default);
    Task<SubmitResponseDto> SubmitAsync(string id, CancellationToken cancellationToken = default);
    Task<ProposalResponseDto> ReviewAsync(string id, ReviewProposalDto dto, CancellationToken cancellationToken = default);
}
