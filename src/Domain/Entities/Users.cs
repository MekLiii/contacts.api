namespace contacts.api.Domain.Entities;

public class User : BaseAuditableEntity
{
    public string? Username { get; set; }
    public string? PasswordHash { get; set; }
    public DateTime? LastLogin { get; set; }
    public bool? IsActive { get; set; }
    
}
