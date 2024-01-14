namespace contacts.api.Domain.Entities;

public class Contact
{
    public int Id { get; set; }
    
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public Category? Category { get; set; } = null!;
    public SubCategory? SubCategory { get; set; } = null!;
    public int? CategoryId { get; set; } = null!;
    public int? SubCategoryId { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public DateTime DateOfBirth { get; set; }
    
}
