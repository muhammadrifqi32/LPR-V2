using System.ComponentModel.DataAnnotations.Schema;

namespace PurchaseRequestSystem.Models;

[Table("tbl_account")]
public class Account
{
    public string AccountId { get; set; }
    public string RoleId { get; set; }
    public string Email { get; set; } = string.Empty;
    /// <summary>BCrypt hash (salt is embedded by BCrypt, so no separate salt column).</summary>
    public string Password { get; set; } = string.Empty;
    public DateTime? LastLoginAt { get; set; }
    public bool IsDeleted { get; set; }

    public DateTime CreatedAt { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string? UpdatedBy { get; set; }

    public Role Role { get; set; } = null!;
    public UserDetail? UserDetail { get; set; }
}
