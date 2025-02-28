﻿namespace Mimo.Domain.Contracts;

public interface IRepositoryManager
{
    ICourseRepository Course { get; }
    
    ILessonRepository Lesson { get; }
    
    IUserLessonProgressRepository Progress { get; }
    
    IAchievementRepository Achievement { get; }
    
    IUserAchievementRepository UserAchievement { get; }
    
    Task SaveAsync(CancellationToken token = default);
}