using LibrarySystem.Core.Interfaces;
using LibrarySystem.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LibrarySystem.Infrastructure.DIExtensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ISubCategoryRepository, SubCategoryRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IDbInitializer, DbInitializer>();

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration["ConnectionStrings:DefaultConnection"],
                b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            return services;
        }

    }
}
