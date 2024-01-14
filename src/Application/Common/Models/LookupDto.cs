using Microsoft.Extensions.DependencyInjection.Contacts.Queries.GetContacts;
using Contact = contacts.api.Domain.Entities.Contact;

namespace contacts.api.Application.Common.Models;

public class LookupDto
{
    

    private class Mapping : Profile
    {
        public Mapping()
        {
            
            CreateMap<Contact, ContactShortDto>();
        }
    }
}
