using contacts.api.Application.Contacts.Commands.GetContactById;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection.Contacts.Commands;
using Microsoft.Extensions.DependencyInjection.Contacts.Commands.UpdateContactCommand;
using Microsoft.Extensions.DependencyInjection.Contacts.Queries.GetContacts;


namespace contacts.api.Web.Endpoints;

public class Contacts : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .MapGet(GetContacts);

        app.MapGroup(this)
            .RequireAuthorization()
            .MapGet("/{id}", GetContactById);

        app.MapGroup(this)
            .RequireAuthorization()
            .MapDelete("/{id}", DeleteContact);

        app.MapGroup(this)
            .RequireAuthorization()
            .MapPost("/{id}", UpdateContact);
    }

    public async Task<IEnumerable<ContactShortDto>> GetContacts(ISender sender)
    {
        return await sender.Send(new GetContactsQuery());
    }

    public async Task<ContactDto> GetContactById(ISender sender, [FromRoute] int id)
    {
        return await sender.Send(new GetContactByIdCommand(id));
    }

    public async Task<IResult> DeleteContact(ISender sender, [FromRoute] int id)
    {
        await sender.Send(new DeleteContact(id));
        return Results.NoContent();
    }

    public async Task<IResult> UpdateContact(ISender sender, [FromRoute] int id, [FromBody] UpdateContactCommand command)
    {
        if (id != command.Id) return Results.BadRequest();
        await sender.Send(command);
        return Results.NoContent();
    }
}
