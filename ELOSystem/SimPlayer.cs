namespace ELOSystem;

public class SimPlayer
{
    public double Rating { get; set; } = 1200;
    public double WinRate { get; init; }

    public SimPlayer(double winrate, int rating = 1200)
    {
        if (winrate < 0 || winrate > 1) 
            throw new ArgumentException("bad winrate");

        Rating = rating;
        WinRate = winrate;
    }
}