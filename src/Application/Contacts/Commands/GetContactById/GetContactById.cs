using contacts.api.Application.Common.Interfaces;
using Microsoft.Extensions.DependencyInjection.Contacts.Queries.GetContacts;

namespace contacts.api.Application.Contacts.Commands.GetContactById;

public record GetContactByIdCommand(int Id) : IRequest<Contact>;

public class GetContactByIdCommandHandler : IRequestHandler<GetContactByIdCommand, Contact>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetContactByIdCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Contact> Handle(GetContactByIdCommand request, CancellationToken cancellationToken)
    {
        var contact = await _context.Contacts
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        Guard.Against.NotFound(request.Id, contact);
        
        return _mapper.Map<Contact>(contact);
    }
}
