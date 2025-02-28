using Mimo.Application.DTOs;
using Mimo.Domain.DTOs;

namespace Mimo.Application.Mappers;

public static class UserLessonProgressMapper
{
    public static UserLessonProgressDto ToUserLessonProgressDto(this UserLessonProgressQueryDto progress) => new()
    {
        LessonName = progress.LessonName,
        LessonId = progress.LessonId,
        NumberOfAttempts = progress.NumberOfAttempts,
        DateStarted = progress.DateStarted.ToString("G"),
        DateFinished = progress.DateFinished?.ToString("G") ?? string.Empty,
        Completed = progress.DateFinished.HasValue,
    };

    public static IEnumerable<UserLessonProgressDto> ToUserLessonProgressDtoList(
        this IEnumerable<UserLessonProgressQueryDto> progresses) =>
        progresses.Select(c => c.ToUserLessonProgressDto());
}