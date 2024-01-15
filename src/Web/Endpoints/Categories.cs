using Microsoft.Extensions.DependencyInjection.Categories.Queries;

namespace contacts.api.Web.Endpoints;

public class Categories : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            // .RequireAuthorization()
            .MapGet(GetCategories);


    }
    
    public async Task<IEnumerable<CategoryDto>> GetCategories(ISender sender)
    {
        return await sender.Send(new GetCategories());
    }
}
