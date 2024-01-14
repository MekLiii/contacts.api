namespace contacts.api.Domain.Entities;

public class Contact :BaseAuditableEntity
{
    
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string Category { get; set; } = null!;
    public string SubCategory { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public DateTime DateOfBirth { get; set; }
    
}
