using Mimo.Application.Contracts;
using Mimo.Application.DTOs;
using Mimo.Application.Mappers;
using Mimo.Domain.Contracts;

namespace Mimo.Application.Services;

public class CourseService(ICourseRepository courseRepository) : ICourseService
{
    public async Task<IEnumerable<CourseDto>> GetAllCoursesAsync(CancellationToken token = default)
    {
        var courses = await courseRepository.GetAllCoursesAsync(false, token);
        var mappedCourses = courses.ToCourseDtoList();
        return mappedCourses;
    }

    public async Task<CourseDto?> GetCourseByIdAsync(Guid courseId, CancellationToken token = default)
    {
        var course = await courseRepository.GetCourseWithAllDataAsync(courseId, token);
        var mappedCourse = course?.ToCourseDto();
        return mappedCourse;
    }
}