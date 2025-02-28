using Microsoft.Extensions.DependencyInjection;
using Mimo.Application.Contracts;
using Mimo.Application.Services;

namespace Mimo.Application;

public static class ServiceExtensions
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<ICourseService, CourseService>();
        services.AddScoped<ILessonService, LessonService>();
        services.AddScoped<IUserLessonProgressService, UserLessonProgressService>();
    }
}