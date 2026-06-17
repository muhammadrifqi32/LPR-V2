namespace PurchaseRequestSystem.DTOs;

public class GeneratePurchaseOrderDto
{
    public string? VendorId { get; set; }
    public string? CompanyId { get; set; }
    public string? TaxId { get; set; }
    public DateTime PoDate { get; set; }
    public decimal TaxRate { get; set; }
    public string? Notes { get; set; }
    public string? PurchaseOrderAttachmentPath { get; set; }
    public string CreatedBy { get; set; }
    public List<GeneratePurchaseOrderDetailDto> Details { get; set; } = new();
}

public class GeneratePurchaseOrderDetailDto
{
    public string PurchaseRequestDetailId { get; set; }
    /// <summary>Optional for backward compatibility. If 0, full remaining/requested quantity will be used.</summary>
    public decimal OrderQuantity { get; set; }
    public decimal UnitPrice { get; set; }
    public string? Notes { get; set; }
}

public class UpdatePurchaseOrderDto
{
    public string? VendorId { get; set; }
    public string? CompanyId { get; set; }
    public string? TaxId { get; set; }
    public DateTime PoDate { get; set; }
    public decimal TaxRate { get; set; }
    public string? Notes { get; set; }
    public string? PurchaseOrderAttachmentPath { get; set; }
    public string UpdatedBy { get; set; }
    public List<UpdatePurchaseOrderDetailDto> Details { get; set; } = new();
}

public class UpdatePurchaseOrderDetailDto
{
    public string PurchaseOrderDetailId { get; set; }
    public decimal OrderQuantity { get; set; }
    public decimal UnitPrice { get; set; }
    public string? Notes { get; set; }
}

public class PurchaseOrderResponseDto
{
    public string PurchaseOrderId { get; set; }
    public string PurchaseRequestId { get; set; }
    public string PurchaseOrderNo { get; set; } = string.Empty;
    public string? VendorId { get; set; }
    public string? VendorName { get; set; }
    public string? CompanyId { get; set; }
    public string? CompanyName { get; set; }
    public string? TaxId { get; set; }
    public string? TaxName { get; set; }
    public DateTime PoDate { get; set; }
    public string StatusId { get; set; }
    public string Status { get; set; } = string.Empty;
    public string? Notes { get; set; }
    public decimal SubtotalAmount { get; set; }
    public decimal TaxRate { get; set; }
    public decimal TaxAmount { get; set; }
    public decimal GrandtotalAmount { get; set; }
    public string? PurchaseOrderAttachmentPath { get; set; }
    public DateTime CreatedAt { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string? UpdatedBy { get; set; }
    public List<PurchaseOrderDetailResponseDto> Details { get; set; } = new();
}

public class PurchaseOrderDetailResponseDto
{
    public string PurchaseOrderDetailId { get; set; }
    public string MaterialId { get; set; }
    public string? MaterialCode { get; set; }
    public string MaterialName { get; set; } = string.Empty;
    public string UomId { get; set; }
    public string? UomCode { get; set; }
    public string UomName { get; set; } = string.Empty;
    public int DetailNo { get; set; }
    public decimal OrderQuantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal SubtotalAmount { get; set; }
    public string? Notes { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}
