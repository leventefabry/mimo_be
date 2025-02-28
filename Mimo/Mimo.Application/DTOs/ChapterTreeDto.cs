namespace Mimo.Application.DTOs;

public readonly record struct ChapterTreeDto
{
    public Guid Id { get; init; }

    public HashSet<Guid> LessonIds { get; init; }
}