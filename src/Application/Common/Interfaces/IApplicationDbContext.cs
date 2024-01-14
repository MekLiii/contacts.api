using contacts.api.Domain.Entities;

namespace contacts.api.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    
    DbSet<Contact> Contacts { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    
    
}
