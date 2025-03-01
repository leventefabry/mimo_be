using Mimo.Application.DTOs;
using Mimo.Domain.Entities;

namespace Mimo.Application.Mappers;

public static class AchievementMapper
{
    public static NewAchievementDto ToNewAchievementDto(this Achievement achievement) => new()
    {
        Id = achievement.Id,
        Name = achievement.Name,
    };
    
    public static IEnumerable<NewAchievementDto> ToNewAchievementDtoList(this IEnumerable<Achievement> achievements) => 
        achievements.Select(c => c.ToNewAchievementDto());
}