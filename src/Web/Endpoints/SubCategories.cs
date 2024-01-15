using Microsoft.Extensions.DependencyInjection.Categories.Queries;

namespace contacts.api.Web.Endpoints;

public class SubCategories : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            // .RequireAuthorization()
            .MapGet(GetSubCategories);


    }
    
    public async Task<IEnumerable<SubCategoryDto>> GetSubCategories(ISender sender)
    {
        return await sender.Send(new GetSubCategories());
    }
}
