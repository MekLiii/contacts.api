﻿using contacts.api.Domain.Entities;
using contacts.api.Infrastructure.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace contacts.api.Infrastructure.Data;

public static class InitialiserExtensions
{
    public static async Task InitialiseDatabaseAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        var initialiser = scope.ServiceProvider.GetRequiredService<ApplicationDbContextInitialiser>();

        await initialiser.InitialiseAsync();

        await initialiser.SeedAsync();
    }
}

public class ApplicationDbContextInitialiser
{
    private readonly ILogger<ApplicationDbContextInitialiser> _logger;
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public ApplicationDbContextInitialiser(ILogger<ApplicationDbContextInitialiser> logger,
        ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        _logger = logger;
        _context = context;
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task InitialiseAsync()
    {
        try
        {
            await _context.Database.MigrateAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while initialising the database.");
            throw;
        }
    }

    public async Task SeedAsync()
    {
        try
        {
            await TrySeedAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while seeding the database.");
            throw;
        }
    }

    public async Task TrySeedAsync()
    {
        if (!_context.Category.Any())
        {
            for (int i = 0; i < 10; i++)
            {
                _context.Category.Add(new Category() { Id = i + 1, Name = $"Category{i}", });
            }
        }

        if (!_context.SubCategory.Any())
        {
            for (int i = 0; i < 10; i++)
            {
                _context.SubCategory.Add(new SubCategory() { Id = i + 1, Name = $"Category{i}", });
            }
        }

        if (!_context.Contacts.Any())
        {
            for (int i = 0; i < 10; i++)
            {
                if (i % 2 == 0)
                {
                    _context.Contacts.Add(new Contact()
                    {
                        FirstName = $"John{i}",
                        LastName = $"Doe{i}",
                        Email = $"John@doe{i}.com",
                        Password = "Password",
                        Category = new Category() { Id = 1, Name = $"Category{i}", },
                        SubCategory =
                            new SubCategory() { Id = 1, Name = $"Category{i}", },
                        Phone = "123456789",
                    });
                }

                if (i % 2 != 0)
                {
                    _context.Contacts.Add(new Contact()
                    {
                        FirstName = $"John{i}",
                        LastName = $"Doe{i}",
                        Email = $"John@doe{i}.com",
                        Password = "Password",
                        CategoryId = 1,
                        SubCategoryId = 1,
                        Phone = "123456789",
                    });
                }
            }
        }

        await _context.SaveChangesAsync();
    }
}
