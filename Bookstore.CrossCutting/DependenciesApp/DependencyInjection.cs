using Bookstore.Domain.Interface;
using Bookstore.Infrastructure.Context;
using Bookstore.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Bookstore.CrossCutting.DependenciesApp;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrasctructure(this IServiceCollection services,
                                                        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<ApplicationDbContext>(opt => opt.UseSqlServer(connectionString));

        services.AddScoped<IBookRepository, BookRepository>();

        return services;
    }
}
