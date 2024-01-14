using contacts.api.Application.Common.Interfaces;

namespace Microsoft.Extensions.DependencyInjection.Contacts.Commands;


public record DeleteContact(int Id) : IRequest;

public class DeleteContactCommandHandler : IRequestHandler<DeleteContact>
{
    private readonly IApplicationDbContext _context;
    
    public DeleteContactCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task Handle(DeleteContact request, CancellationToken cancellationToken)
    {
        var contact = await _context.Contacts
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        Guard.Against.NotFound(request.Id, contact);
        
        _context.Contacts.Remove(contact);
        await _context.SaveChangesAsync(cancellationToken);
    }
    
}
