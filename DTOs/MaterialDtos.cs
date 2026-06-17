namespace PurchaseRequestSystem.DTOs;

public class CreateMaterialDto
{
    public string UomId { get; set; }
    public string? MaterialCode { get; set; }
    public string? MaterialName { get; set; }
    public string? Description { get; set; }
}

public class UpdateMaterialDto
{
    public string UomId { get; set; }
    public string? MaterialCode { get; set; }
    public string? MaterialName { get; set; }
    public string? Description { get; set; }
}

public class MaterialResponseDto
{
    public string MaterialId { get; set; }
    public string UomId { get; set; }
    public string UomCode { get; set; } = string.Empty;
    public string UomName { get; set; } = string.Empty;
    public string MaterialCode { get; set; } = string.Empty;
    public string MaterialName { get; set; } = string.Empty;
    public string? Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}
