using Microsoft.EntityFrameworkCore;
using Mimo.Domain.Contracts;
using Mimo.Domain.Entities;
using Mimo.Persistence.Data;

namespace Mimo.Persistence.Repositories;

public class CourseRepository(MimoDbContext context) : RepositoryBase<Course>(context), ICourseRepository
{
    public async Task<IEnumerable<Course>> GetAllCoursesAsync(bool trackChanges, CancellationToken token = default) => 
        await FindAll(trackChanges)
        .OrderBy(c => c.Name)
        .ToListAsync(token);
    
    public async Task<Course?> GetCourseByIdAsync(Guid chapterId, bool trackChanges) => 
        await FindByCondition(c => c.Id.Equals(chapterId), trackChanges)
            .SingleOrDefaultAsync();
    
    public void CreateCourse(Course course) => Create(course);

    public void DeleteCourse(Course course) => Delete(course);
}