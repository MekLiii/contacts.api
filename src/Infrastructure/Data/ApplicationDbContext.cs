using System.Reflection;
using contacts.api.Application.Common.Interfaces;
using contacts.api.Domain.Entities;
using contacts.api.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace contacts.api.Infrastructure.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        Contacts = Set<Contact>();
        Category = Set<Category>();
        SubCategory = Set<SubCategory>();
    }

    public DbSet<Contact> Contacts { get; set; }
    public DbSet<Category> Category { get; set; }
    public DbSet<SubCategory> SubCategory { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);
    }
}
