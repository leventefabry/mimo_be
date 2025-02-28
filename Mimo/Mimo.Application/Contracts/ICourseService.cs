using Mimo.Application.DTOs;

namespace Mimo.Application.Contracts;

public interface ICourseService
{
    Task<IEnumerable<CourseDto>> GetAllCoursesAsync(CancellationToken token = default);
    
    Task<CourseDto?> GetCourseByIdAsync(Guid courseId, CancellationToken token = default);
}