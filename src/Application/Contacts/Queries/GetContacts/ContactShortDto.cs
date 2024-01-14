namespace Microsoft.Extensions.DependencyInjection.Contacts.Queries.GetContacts;

public class ContactShortDto
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public int Id { get; set; }

}
