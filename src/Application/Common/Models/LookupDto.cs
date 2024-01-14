using Microsoft.Extensions.DependencyInjection.Contacts.Queries.GetContacts;


namespace contacts.api.Application.Common.Models;

public class LookupDto
{
    

    private class Mapping : Profile
    {
        public Mapping()
        {
            
            CreateMap<Domain.Entities.Contact, ContactShortDto>();
            CreateMap<Contact,Contact>();
            CreateMap<Domain.Entities.Contact,ContactDto>();
        }
    }
}
