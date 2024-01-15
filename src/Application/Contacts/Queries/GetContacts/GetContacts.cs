using contacts.api.Application.Common.Interfaces;

namespace Microsoft.Extensions.DependencyInjection.Contacts.Queries.GetContacts;


public record GetContacts : IRequest<IEnumerable<ContactShortDto>>;

public class GetContactsQueryHandler : IRequestHandler<GetContacts, IEnumerable<ContactShortDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetContactsQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ContactShortDto>> Handle(GetContacts request, CancellationToken cancellationToken)
    {
        var contacts = await _context.Contacts
            .ProjectTo<ContactShortDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return contacts;
    }
    
}
