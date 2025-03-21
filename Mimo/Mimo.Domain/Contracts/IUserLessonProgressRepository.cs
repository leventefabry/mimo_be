﻿using Mimo.Domain.DTOs;
using Mimo.Domain.Entities;

namespace Mimo.Domain.Contracts;

public interface IUserLessonProgressRepository
{
    Task<UserLessonProgress?> GetUserLessonProgressByLessonIdAsync(Guid userId, Guid lessonId,
        CancellationToken token = default);

    Task<IEnumerable<UserLessonProgressQueryDto>> GetProgressByUserIdIdAsync(Guid userId,
        CancellationToken token = default);

    Task<IEnumerable<Guid>> GetFinishedLessonGuidsByUserIdIdAsync(Guid userId, CancellationToken token = default);

    void CreateUserLessonProgress(Guid userId, Guid lessonId);
}