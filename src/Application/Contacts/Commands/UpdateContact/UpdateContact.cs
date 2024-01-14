using contacts.api.Application.Common.Interfaces;
using contacts.api.Domain.Entities;

namespace Microsoft.Extensions.DependencyInjection.Contacts.Commands.UpdateContactCommand;

public record UpdateContactCommand : IRequest 
{
    public int Id { get; init; }
    public string? FirstName { get; init; }
    public string? LastName { get; init; } 
    public string? Email { get; init; } 
    public int? CategoryId { get; init; } 
    public int? SubCategoryId { get; init; } 
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
        if (request.CategoryId.HasValue)
        {
            var category = await _context.Category.FirstOrDefaultAsync(c => c.Id == request.CategoryId, cancellationToken);
            contact.Category = category;
        }
        if (request.SubCategoryId.HasValue)
        {
            var subCategory = await _context.SubCategory.FirstOrDefaultAsync(c => c.Id == request.SubCategoryId, cancellationToken);
            contact.SubCategory = subCategory;
        }
        
        contact.FirstName = request.FirstName ?? contact.FirstName;
        contact.LastName = request.LastName ?? contact.LastName;
        contact.Email = request.Email ?? contact.Email;
        contact.Phone = request.Phone ?? contact.Phone;
        contact.DateOfBirth = request.DateOfBirth ?? contact.DateOfBirth;
        
        await _context.SaveChangesAsync(cancellationToken);
    }
    
}
