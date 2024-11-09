using DTO.Data.Entities;

namespace ELOSystem;

public class ELOCalculator
{
    // Parameters for fine-tuning of ELO Algorithm
    private const int K = 30;
    private const int ScoreWeight = 10;
    private const double TeamFactor = 0.8;


    /// <summary>
    /// Calculates the new ratings for the teams
    /// </summary>
    /// <param name="teamA"> first player</param>
    /// <param name="teamB"> second player</param>
    /// <param name="score"> scores of the game</param>
    /// <exception cref="ArgumentException"> Throws error if Team is empty</exception>
    public void UpdateRatings(List<PlayerEntity> teamA, List<PlayerEntity> teamB, (int A, int B) score)
    {
        double ratingTeamA = TeamRating(teamA);
        double ratingTeamB = TeamRating(teamB);
        (double A, double B) changes = CalculateChange(ratingTeamA, ratingTeamB, score);

        teamA.ForEach(a => a.Rating += (changes.A / teamA.Count));
        teamB.ForEach(b => b.Rating += (changes.B / teamB.Count));

        double TeamRating(List<PlayerEntity> players)
        {
            return players.Count switch
            {
                0 => throw new ArgumentException("Cannot update rating on non-existing team"),
                1 => players[0].Rating,
                _ => players.Sum(x => x.Rating) * TeamFactor
            };
        }
    }

    /// <summary>
    /// Calculates the new ratings for the players
    /// </summary>
    /// <param name="playerA"> first player</param>
    /// <param name="playerB"> second player</param>
    /// <param name="score">Tuple with scores of the game</param>
    public void UpdateRatings(PlayerEntity playerA, PlayerEntity playerB, (int A, int B) score)
    {
        UpdateRatings([playerA], [playerB], score);
    }
    
    private (double, double) CalculateChange(double playerA, double playerB, (int scoreA, int scoreB) score)
    {
        int Outcome(int x) => (x > 0) ? 1 : 0;

        double QA = Math.Pow(10, playerA / 400);
        double QB = Math.Pow(10, playerB / 400);
        double W = Weight(score.scoreA, score.scoreB);

        double changeA = W * K * (Outcome(score.scoreA - score.scoreB) - Expectation(QA, QB));
        double changeB = W * K * (Outcome(score.scoreB - score.scoreA) - Expectation(QB, QA));
        
        double Expectation(double Q1, double Q2)
        {
            return Q1 / (Q1 + Q2);
        }

        double Weight(int x, int y)
        {
            if (Math.Min(x, y) == 0) return 1.15; // +5% for egg
            return 1 + (Math.Abs(x - y) / Math.Max(x, y) * ScoreWeight);
        }

        return (changeA, changeB);
    }
}