using contacts.api.Domain.Entities;
using Microsoft.Extensions.DependencyInjection.Categories.Queries;
using Microsoft.Extensions.DependencyInjection.Contacts.Queries.GetContacts;
using Contact = Microsoft.Extensions.DependencyInjection.Contacts.Queries.GetContacts.Contact;


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

            CreateMap<Category, CategoryDto>();
            CreateMap<SubCategory, SubCategoryDto>();
        }
    }
}
