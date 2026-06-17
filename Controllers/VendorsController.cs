using Microsoft.AspNetCore.Mvc;
using PurchaseRequestSystem.Common;
using PurchaseRequestSystem.DTOs;
using PurchaseRequestSystem.Interfaces;

namespace PurchaseRequestSystem.Controllers;

[ApiController]
[Route("api/vendors")]
public class VendorsController : ControllerBase
{
    private readonly IVendorService _service;

    public VendorsController(IVendorService service)
    {
        _service = service;
    }

    [HttpGet]
    [ProducesResponseType(typeof(ApiResponse<IReadOnlyList<VendorResponseDto>>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var result = await _service.GetAllAsync(cancellationToken);
        return Ok(ApiResponse<IReadOnlyList<VendorResponseDto>>.Success(result, "Data retrieved successfully"));
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ApiResponse<VendorResponseDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(string id, CancellationToken cancellationToken)
    {
        var result = await _service.GetByIdAsync(id, cancellationToken);
        return Ok(ApiResponse<VendorResponseDto>.Success(result, "Data retrieved successfully"));
    }

    [HttpPost]
    [ProducesResponseType(typeof(ApiResponse<VendorResponseDto>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse<ValidationErrorData>), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody] CreateVendorDto dto, CancellationToken cancellationToken)
    {
        var result = await _service.CreateAsync(dto, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = result.VendorId }, ApiResponse<VendorResponseDto>.Created(result, "Data created successfully"));
    }

    [HttpPut("{id}")]
    [ProducesResponseType(typeof(ApiResponse<VendorResponseDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse<ValidationErrorData>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(string id, [FromBody] UpdateVendorDto dto, CancellationToken cancellationToken)
    {
        var result = await _service.UpdateAsync(id, dto, cancellationToken);
        return Ok(ApiResponse<VendorResponseDto>.Success(result, "Data updated successfully"));
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(string id, CancellationToken cancellationToken)
    {
        await _service.DeleteAsync(id, cancellationToken);
        return Ok(ApiResponse<object>.Success(null, "Data deleted successfully"));
    }
}
