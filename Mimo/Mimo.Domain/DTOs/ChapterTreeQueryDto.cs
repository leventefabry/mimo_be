namespace Mimo.Domain.DTOs;

public readonly record struct ChapterTreeQueryDto
{
    public Guid Id { get; init; }

    public HashSet<Guid> LessonIds { get; init; }
}