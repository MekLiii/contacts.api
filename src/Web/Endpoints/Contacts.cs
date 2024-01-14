
using Microsoft.Extensions.DependencyInjection.Contacts.Queries.GetContacts;

namespace contacts.api.Web.Endpoints;

public class Contacts : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .MapGet(GetContacts);
        
    }
    public async Task<IEnumerable<ContactShortDto>> GetContacts(ISender sender)
    {
        return await sender.Send(new GetContactsQuery());
    }
   
    
}
