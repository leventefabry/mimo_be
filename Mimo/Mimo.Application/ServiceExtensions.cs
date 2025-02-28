using Microsoft.Extensions.DependencyInjection;
using Mimo.Application.Contracts;
using Mimo.Application.Contracts.AchievementValidators;
using Mimo.Application.Services;
using Mimo.Application.Services.AchievementFactory;

namespace Mimo.Application;

public static class ServiceExtensions
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<ICourseService, CourseService>();
        services.AddScoped<ILessonService, LessonService>();
        services.AddScoped<IUserLessonProgressService, UserLessonProgressService>();
        services.AddScoped<IAchievementService, AchievementService>();
        
        services.AddScoped<IAchievementFactory, AchievementFactory>();
        services.AddScoped<IAchievementValidator, LessonCountValidator>();
        services.AddScoped<IAchievementValidator, ChapterCountValidator>();
        services.AddScoped<IAchievementValidator, CourseCompletionValidator>();
    }
}