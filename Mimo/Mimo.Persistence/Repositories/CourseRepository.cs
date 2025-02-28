using Microsoft.EntityFrameworkCore;
using Mimo.Domain.Contracts;
using Mimo.Domain.DTOs;
using Mimo.Domain.Entities;
using Mimo.Persistence.Data;

namespace Mimo.Persistence.Repositories;

public class CourseRepository(MimoDbContext context) : RepositoryBase<Course>(context), ICourseRepository
{
    public async Task<IEnumerable<Course>> GetAllCoursesAsync(bool trackChanges, CancellationToken token = default) =>
        await FindAll(trackChanges)
            .OrderBy(c => c.Name)
            .ToListAsync(token);

    public async Task<CourseQueryDto?> GetCourseWithAllDataAsync(Guid courseId, CancellationToken token = default) =>
        await FindByCondition(c => c.Id.Equals(courseId), false)
            .Select(c => new CourseQueryDto
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description,
                Chapters = c.Chapters
                    .OrderBy(ch => ch.Order)
                    .Select(ch => new ChapterQueryDto
                    {
                        Id = ch.Id,
                        Name = ch.Name,
                        Description = ch.Description,
                        Order = ch.Order,
                        Lessons = ch.Lessons
                            .OrderBy(l => l.Order)
                            .Select(l => new LessonQueryDto
                            {
                                Id = l.Id,
                                Name = l.Name,
                                Order = l.Order,
                                Description = l.Description
                            })
                    })
            })
            .SingleOrDefaultAsync(token);

    public async Task<Course?> GetCourseByIdAsync(Guid courseId, bool trackChanges) =>
        await FindByCondition(c => c.Id.Equals(courseId), trackChanges)
            .SingleOrDefaultAsync();

    public void CreateCourse(Course course) => Create(course);

    public void DeleteCourse(Course course) => Delete(course);
}