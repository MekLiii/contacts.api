using contacts.api.Application.Common.Interfaces;

namespace Microsoft.Extensions.DependencyInjection.Categories.Queries;

public record GetSubCategories : IRequest<IEnumerable<SubCategoryDto>>;

public class GetSubCategoriesQueryHandler : IRequestHandler<GetSubCategories, IEnumerable<SubCategoryDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetSubCategoriesQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
   public async Task<IEnumerable<SubCategoryDto>> Handle(GetSubCategories request, CancellationToken cancellationToken)
    {
        var subCategories = await _context.SubCategory
            .ProjectTo<SubCategoryDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return subCategories;
    }
}
