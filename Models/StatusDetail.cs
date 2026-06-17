using System.ComponentModel.DataAnnotations.Schema;

namespace PurchaseRequestSystem.Models;

[Table("tbl_status_detail")]
public class StatusDetail
{
    public string StatusDetailId { get; set; } = string.Empty;
    public string StatusId { get; set; } = string.Empty;
    public string ModuleTypeId { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    public Status Status { get; set; } = null!;
    public ModuleType ModuleType { get; set; } = null!;
}
