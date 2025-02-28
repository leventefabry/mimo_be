using Mimo.Domain.Entities;

namespace Mimo.Domain.Contracts;

public interface ICourseRepository
{
    Task<IEnumerable<Course>> GetAllCoursesAsync(bool trackChanges, CancellationToken token = default);

    Task<Course?> GetCourseByIdAsync(Guid chapterId, bool trackChanges);

    void CreateCourse(Course course);

    void DeleteCourse(Course course);
}