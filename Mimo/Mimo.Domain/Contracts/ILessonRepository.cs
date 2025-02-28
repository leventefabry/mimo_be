using Mimo.Domain.Entities;

namespace Mimo.Domain.Contracts;

public interface ILessonRepository
{
    Task<Lesson?> GetLessonByIdAsync(Guid lessonId, bool trackChanges, CancellationToken token = default);
}