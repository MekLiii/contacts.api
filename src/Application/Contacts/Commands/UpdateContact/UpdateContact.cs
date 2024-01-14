using contacts.api.Application.Common.Interfaces;

namespace Microsoft.Extensions.DependencyInjection.Contacts.Commands.UpdateContactCommand;

public record UpdateContactCommand : IRequest 
{
    public int Id { get; init; }
    public string? FirstName { get; init; }
    public string? LastName { get; init; } 
    public string? Email { get; init; } 
    public string? Category { get; init; } 
    public string? SubCategory { get; init; } 
    public string? Phone { get; init; }
    public DateTime? DateOfBirth { get; init; }
}

public class UpdateContactCommandHandler : IRequestHandler<UpdateContactCommand> 
{
    private readonly IApplicationDbContext _context;
    public UpdateContactCommandHandler(IApplicationDbContext context)
    {
        _context = context;
        
    }

    public async Task Handle(UpdateContactCommand request, CancellationToken cancellationToken)
    {
        var contact = await _context.Contacts.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        Guard.Against.NotFound(request.Id, contact);
        
        contact.FirstName = request.FirstName ?? contact.FirstName;
        contact.LastName = request.LastName ?? contact.LastName;
        contact.Email = request.Email ?? contact.Email;
        contact.Category = request.Category ?? contact.Category;
        contact.SubCategory = request.SubCategory ?? contact.SubCategory;
        contact.Phone = request.Phone ?? contact.Phone;
        contact.DateOfBirth = request.DateOfBirth ?? contact.DateOfBirth;
        
        await _context.SaveChangesAsync(cancellationToken);
    }
    
}
