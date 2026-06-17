using System.ComponentModel.DataAnnotations.Schema;
using PurchaseRequestSystem.Common.Enums;

namespace PurchaseRequestSystem.Models;

[Table("tbl_goods_receipt_detail")]
public class GoodsReceiptDetail
{
    public string GoodsReceiptDetailId { get; set; }
    public string GoodsReceiptId { get; set; }
    /// <summary>Links the received line to the specific PO line for qty matching.</summary>
    public string PurchaseOrderDetailId { get; set; }
    public string MaterialId { get; set; }
    public string UomId { get; set; }
    public int DetailNo { get; set; }
    public decimal ReceivedQty { get; set; }
    public bool IsMatchPo { get; set; }
    public DiscrepancyType? DiscrepancyType { get; set; }
    public string? Remarks { get; set; }
    public string? GoodsReceiptAttachmentPath { get; set; }

    public DateTime CreatedAt { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string? UpdatedBy { get; set; }

    public GoodsReceipt GoodsReceipt { get; set; } = null!;
    public PurchaseOrderDetail PurchaseOrderDetail { get; set; } = null!;
    public Material Material { get; set; } = null!;
    public Uom Uom { get; set; } = null!;
}
