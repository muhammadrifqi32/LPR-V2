using Microsoft.AspNetCore.Mvc;
using PurchaseRequestSystem.Common;
using PurchaseRequestSystem.DTOs;
using PurchaseRequestSystem.Interfaces;

namespace PurchaseRequestSystem.Controllers;

[ApiController]
[Route("api/proposals")]
public class ProposalController : ControllerBase
{
    private readonly IProposalService _proposalService;

    public ProposalController(IProposalService proposalService)
    {
        _proposalService = proposalService;
    }

    [HttpGet]
    [ProducesResponseType(typeof(ApiResponse<IReadOnlyList<ProposalResponseDto>>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var result = await _proposalService.GetAllAsync(cancellationToken);
        return Ok(ApiResponse<IReadOnlyList<ProposalResponseDto>>.Success(result, "Data retrieved successfully"));
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ApiResponse<ProposalResponseDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(string id, CancellationToken cancellationToken)
    {
        var result = await _proposalService.GetByIdAsync(id, cancellationToken);
        return Ok(ApiResponse<ProposalResponseDto>.Success(result, "Data retrieved successfully"));
    }

    [HttpPost]
    [ProducesResponseType(typeof(ApiResponse<ProposalResponseDto>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse<ValidationErrorData>), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody] CreateProposalDto dto, CancellationToken cancellationToken)
    {
        var result = await _proposalService.CreateAsync(dto, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = result.ProposalId }, ApiResponse<ProposalResponseDto>.Created(result, "Data created successfully"));
    }

    [HttpPut("{id}")]
    [ProducesResponseType(typeof(ApiResponse<ProposalResponseDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse<ValidationErrorData>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(string id, [FromBody] UpdateProposalDto dto, CancellationToken cancellationToken)
    {
        var result = await _proposalService.UpdateAsync(id, dto, cancellationToken);
        return Ok(ApiResponse<ProposalResponseDto>.Success(result, "Data updated successfully"));
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(string id, CancellationToken cancellationToken)
    {
        await _proposalService.DeleteAsync(id, cancellationToken);
        return Ok(ApiResponse<object>.Success(null, "Data deleted successfully"));
    }

    [HttpPost("{id}/submit")]
    [ProducesResponseType(typeof(ApiResponse<SubmitResponseDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse<ValidationErrorData>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Submit(string id, CancellationToken cancellationToken)
    {
        var result = await _proposalService.SubmitAsync(id, cancellationToken);
        return Ok(ApiResponse<SubmitResponseDto>.Success(result, "Proposal submitted successfully"));
    }

    [HttpPost("{id}/review")]
    [ProducesResponseType(typeof(ApiResponse<ProposalResponseDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse<ValidationErrorData>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Review(string id, [FromBody] ReviewProposalDto dto, CancellationToken cancellationToken)
    {
        var result = await _proposalService.ReviewAsync(id, dto, cancellationToken);
        return Ok(ApiResponse<ProposalResponseDto>.Success(result, "Proposal reviewed successfully"));
    }
}
