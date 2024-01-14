using contacts.api.Domain.Entities;

namespace contacts.api.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    
    DbSet<Contact> Contacts { get; set; }
    DbSet<Category> Category { get; set; }
    DbSet<SubCategory> SubCategory { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    
    
}
