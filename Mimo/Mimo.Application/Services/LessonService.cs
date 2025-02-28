using Mimo.Application.Contracts;
using Mimo.Application.DTOs;
using Mimo.Application.Mappers;
using Mimo.Domain.Contracts;

namespace Mimo.Application.Services;

public class LessonService(ILessonRepository lessonRepository) : ILessonService
{
    public async Task<LessonWithCopyDto?> GetLessonByIdAsync(Guid lessonId, CancellationToken token = default)
    {
        var lesson = await lessonRepository.GetLessonByIdAsync(lessonId, false, token);
        return lesson?.ToLessonWithCopyDto();
    }
}