using Mimo.Application.DTOs;
using Mimo.Domain.Common;

namespace Mimo.Application.Contracts;

public interface ILessonService
{
    Task<LessonWithCopyDto?> GetLessonByIdAsync(Guid lessonId, CancellationToken token = default);

    Task<Result<IEnumerable<NewAchievementDto>>> FinishLessonAsync(Guid lessonId, CancellationToken token = default);
}