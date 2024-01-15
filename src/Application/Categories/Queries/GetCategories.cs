using contacts.api.Application.Common.Interfaces;

namespace Microsoft.Extensions.DependencyInjection.Categories.Queries;

public record GetCategories : IRequest<IEnumerable<CategoryDto>>;

public class GetCategoriesQueryHandler : IRequestHandler<GetCategories, IEnumerable<CategoryDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetCategoriesQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
   public async Task<IEnumerable<CategoryDto>> Handle(GetCategories request, CancellationToken cancellationToken)
    {
        var categories = await _context.Category
            .ProjectTo<CategoryDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return categories;
    }
}
