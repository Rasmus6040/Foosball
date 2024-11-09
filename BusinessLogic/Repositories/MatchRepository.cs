using BusinessLogic.Data.Contexts;
using BusinessLogic.Data.Entities;
using DTO.Data;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Repositories;

public class MatchRepository(EloSystemContext context)
{
    public async Task AddAsync(Match match)
    {
        using var transaction = await context.Database.BeginTransactionAsync();

        try
        {
            var matchEntity = new MatchEntity
            {
                TeamAScore = match.TeamA.Score,
                TeamBScore = match.TeamB.Score,
                EloChange = match.EloChange,
                Ranked = match.Ranked,
                Date = match.Date
            };

            context.Matches.Add(matchEntity);
            await context.SaveChangesAsync();

            foreach (int teamAPlayerId in match.TeamA.PlayerIds)
            {
                var playerMatchEntity1 = new PlayerMatchEntity
                {
                    MatchId = matchEntity.Id,
                    PlayerId = teamAPlayerId,
                    Team = 1
                };
                context.PlayerMatches.Add(playerMatchEntity1);
            }

            foreach (int teamBPlayerId in match.TeamB.PlayerIds)
            {
                var playerMatchEntity2 = new PlayerMatchEntity
                {
                    MatchId = matchEntity.Id,
                    PlayerId = teamBPlayerId,
                    Team = 2
                };
                context.PlayerMatches.Add(playerMatchEntity2);
            }

            await context.SaveChangesAsync();
            await transaction.CommitAsync();
        }
        catch
        {
            await transaction.RollbackAsync();
            throw;
        }
    }
}