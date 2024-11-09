using DTO.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Data.Contexts;

public class EloSystemContext : DbContext
{
    public DbSet<MatchEntity> Matches { get; set; }
    public DbSet<PlayerEntity> Players { get; set; }
    public DbSet<PlayerMatchEntity> PlayerMatches { get; set; }

    public EloSystemContext(DbContextOptions<EloSystemContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);


        if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
        {
            InsertDevelopmentData(modelBuilder);
        }
    }

    private static void InsertDevelopmentData(ModelBuilder modelBuilder)
    {
        var playerList = new List<PlayerEntity>()
        {
            new PlayerEntity() { Id = 1, Name = "Johan" },
            new PlayerEntity() { Id = 2, Name = "Rasmus" },
            new PlayerEntity() { Id = 3, Name = "Joachim" },
            new PlayerEntity() { Id = 4, Name = "Christian" },
            new PlayerEntity() { Id = 5, Name = "Mads" }
        };
        modelBuilder.Entity<PlayerEntity>()
            .HasData(playerList);

        var random = new Random();
        var matchList = new List<MatchEntity>();
        var matchAmount = 1000;
        for (int i = 0; i < matchAmount; i++)
        {
            int whichTeamToWin = random.Next(1, 3);
            int teamAScore = whichTeamToWin == 1 ? 5 : random.Next(0, 5);
            int teamBScore = whichTeamToWin == 2 ? 5 : random.Next(0, 5);
            var isRanked = random.Next(0, 20) != 0;
            matchList.Add(new MatchEntity()
            {
                Id = i + 1,
                TeamAScore = teamAScore,
                TeamBScore = teamBScore,
                EloChange = isRanked ? random.Next(8, 13) : 0,
                Ranked = isRanked
            });
        }

        modelBuilder.Entity<MatchEntity>()
            .HasData(matchList);

        var playerMatchList = new List<PlayerMatchEntity>();
        var playerMatchId = 1;
        for (int i = 1; i <= matchAmount; i++)
        {
            var playerIdsForMatch = playerList.Select(p => p.Id).ToList();
            for (int teamNumber = 1; teamNumber <= 2; teamNumber++)
            {
                int randomIndex = random.Next(playerIdsForMatch.Count);
                int playerId = playerIdsForMatch[randomIndex];
                playerIdsForMatch.RemoveAt(randomIndex);
                playerMatchList.Add(new PlayerMatchEntity()
                {
                    Id = playerMatchId,
                    PlayerId = playerId,
                    MatchId = i,
                    Team = teamNumber
                });
                playerMatchId++;
            }
        }

        modelBuilder.Entity<PlayerMatchEntity>()
            .HasData(playerMatchList);
    }
}