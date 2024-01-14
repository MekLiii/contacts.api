using contacts.api.Application.Common.Interfaces;

namespace Microsoft.Extensions.DependencyInjection.Contacts.Commands;


public record DeleteContactCommand(int Id) : IRequest;

public class DeleteContactCommandHandler : IRequestHandler<DeleteContactCommand>
{
    private readonly IApplicationDbContext _context;
    
    public DeleteContactCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task Handle(DeleteContactCommand request, CancellationToken cancellationToken)
    {
        var contact = await _context.Contacts
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        Guard.Against.NotFound(request.Id, contact);
        
        _context.Contacts.Remove(contact);
        await _context.SaveChangesAsync(cancellationToken);
    }
    
}
