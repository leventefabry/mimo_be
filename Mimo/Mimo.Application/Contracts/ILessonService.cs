﻿using Mimo.Application.DTOs;

namespace Mimo.Application.Contracts;

public interface ILessonService
{
    Task<LessonWithCopyDto?> GetLessonByIdAsync(Guid lessonId, CancellationToken token = default);

    Task<bool> FinishLessonAsync(Guid lessonId, CancellationToken token = default);
}