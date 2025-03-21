﻿using Mimo.Domain.Entities;

namespace Mimo.Domain.Contracts;

public interface IAchievementRepository
{
    Task<IEnumerable<Achievement>> GetAllAchievementsAsync(bool trackChanges, CancellationToken token = default);

    Task<IEnumerable<Achievement>> GetNotFinishedAchievementsAsync(IEnumerable<Guid> except,
        CancellationToken token = default);
}