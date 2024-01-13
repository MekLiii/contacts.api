using contacts.api.Domain.Entities;

namespace contacts.api.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    
    DbSet<User> User { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    
    
}
