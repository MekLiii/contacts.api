using contacts.api.Domain.Entities;

namespace contacts.api.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    
  

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    
    
}
