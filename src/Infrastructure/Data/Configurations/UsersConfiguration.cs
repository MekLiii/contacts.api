using contacts.api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace contacts.api.Infrastructure.Data.Configurations;

public class UsersConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        // builder.ToTable("AspNetUsers");
        
        // builder.Property(u => u.Username)
        //     .HasMaxLength(50)
        //     .IsRequired();
        // builder.Property(u => u.PasswordHash)
        //     .HasMaxLength(255)
        //     .IsRequired();
    
     
    }
}
