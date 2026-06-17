using System.ComponentModel.DataAnnotations.Schema;

namespace PurchaseRequestSystem.Models;

[Table("tbl_module_type")]
public class ModuleType
{
    public string ModuleTypeId { get; set; } = string.Empty;
    public string ModuleTypeCode { get; set; } = string.Empty;
    public string? ModuleTypeDescription { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    public ICollection<StatusDetail> StatusDetails { get; set; } = new List<StatusDetail>();
}
