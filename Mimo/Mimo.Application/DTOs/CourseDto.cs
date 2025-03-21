﻿namespace Mimo.Application.DTOs;

public  readonly record struct CourseDto
{
    public Guid Id { get; init; }
    
    public string Name { get; init; }
    
    public string Description { get; init; }

    public IEnumerable<ChapterDto> Chapters { get; init; }
}