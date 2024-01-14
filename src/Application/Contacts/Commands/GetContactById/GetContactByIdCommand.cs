using contacts.api.Application.Common.Interfaces;
using Microsoft.Extensions.DependencyInjection.Contacts.Queries.GetContacts;

namespace contacts.api.Application.Contacts.Commands.GetContactById;

public record GetContactByIdCommand(int Id) : IRequest<ContactDto>;

public class GetContactByIdCommandHandler : IRequestHandler<GetContactByIdCommand, ContactDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetContactByIdCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ContactDto> Handle(GetContactByIdCommand request, CancellationToken cancellationToken)
    {
        var contact = await _context.Contacts
            .Include(c => c.Category)
            .Include(c => c.SubCategory)
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        Guard.Against.NotFound(request.Id, contact);
        
        return _mapper.Map<ContactDto>(contact);
    }
}
