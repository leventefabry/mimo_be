using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Mimo.Domain.Contracts;
using Mimo.Persistence.Data;
using Mimo.Persistence.Repositories;

namespace Mimo.Persistence;

public static class ServiceExtensions
{
    public static void ConfigureDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<MimoDbContext>(options =>
            options.UseSqlite(configuration.GetConnectionString("DefaultConnection")));
    }
    
    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<ICourseRepository, CourseRepository>();
        services.AddScoped<ILessonRepository, LessonRepository>();
    }
}