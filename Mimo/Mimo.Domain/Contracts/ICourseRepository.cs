using Mimo.Domain.DTOs;
using Mimo.Domain.Entities;

namespace Mimo.Domain.Contracts;

public interface ICourseRepository
{
    Task<IEnumerable<Course>> GetAllCoursesAsync(bool trackChanges, CancellationToken token = default);

    Task<CourseQueryDto?> GetCourseWithAllDataAsync(Guid courseId, CancellationToken token = default);

    Task<Course?> GetCourseByIdAsync(Guid courseId, bool trackChanges, CancellationToken token = default);

    void CreateCourse(Course course);

    void DeleteCourse(Course course);
}