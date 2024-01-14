using contacts.api.Application.Contacts.Commands.GetContactById;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection.Contacts.Queries.GetContacts;


namespace contacts.api.Web.Endpoints;

public class Contacts : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .MapGet(GetContacts)
            .MapGet("/{id}",GetContactById);
    }

    public async Task<IEnumerable<ContactShortDto>> GetContacts(ISender sender)
    {
        return await sender.Send(new GetContactsQuery());
    }

    public async Task<Contact> GetContactById(ISender sender, [FromRoute] int id)
    {
        
        return await sender.Send(new GetContactByIdCommand(id));
    }
}
