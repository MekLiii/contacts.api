using contacts.api.Domain.Entities;

namespace Microsoft.Extensions.DependencyInjection.Contacts.Queries.GetContacts;

public class ContactDto
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public Category Category { get; set; } = null!;
    public SubCategory SubCategory { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public DateTime DateOfBirth { get; set; }
}
