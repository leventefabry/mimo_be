using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Mimo.Application.Contracts;
using Mimo.Application.Services;
using Mimo.Domain.Contracts;
using Mimo.Persistence.Data;
using Mimo.Persistence.Repositories;

namespace Mimo.Application;

public static class ServiceExtensions
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<ICourseService, CourseService>();
    }
}