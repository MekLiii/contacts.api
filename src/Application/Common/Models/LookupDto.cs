using Microsoft.Extensions.DependencyInjection.Contacts.Queries.GetContacts;


namespace contacts.api.Application.Common.Models;

public class LookupDto
{
    

    private class Mapping : Profile
    {
        public Mapping()
        {
            
            CreateMap<Contact, ContactShortDto>();
            CreateMap<Domain.Entities.Contact,Contact>();
        }
    }
}
