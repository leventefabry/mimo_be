using Mimo.Application.Contracts;
using Mimo.Application.DTOs;
using Mimo.Application.Mappers;
using Mimo.Domain.Contracts;

namespace Mimo.Application.Services;

public class CourseService(IRepositoryManager repositoryManager) : ICourseService
{
    public async Task<IEnumerable<CourseDto>> GetAllCoursesAsync(CancellationToken token = default)
    {
        var courses = await repositoryManager.Course.GetAllCoursesAsync(false, token);
        var mappedCourses = courses.ToCourseDtoList();
        return mappedCourses;
    }

    public async Task<CourseDto?> GetCourseByIdAsync(Guid courseId, CancellationToken token = default)
    {
        var course = await repositoryManager.Course.GetCourseWithAllDataAsync(courseId, token);
        var mappedCourse = course?.ToCourseDto();
        return mappedCourse;
    }
}