namespace Microsoft.Extensions.DependencyInjection.Contacts.Queries.GetContacts;

public class Contact
{
    public string FirstName { get; init; } = null!;
    public string LastName { get; init; } = null!;
    public string Email { get; init; } = null!;
    public string Password { get; init; } = null!;
    public string Category { get; init; } = null!;
    public string SubCategory { get; init; } = null!;
    public string Phone { get; init; } = null!;
    public DateTime DateOfBirth { get; init; }
}
