namespace ELOSystem;


using static System.Linq.Enumerable;

Player a = new Player(0.5);
Player b = new Player(0.3);
Tester T = new Tester();

foreach (int i in Range(0, 20))
{
    T.UpdateRating(a, b, (1, 0));
}

T.UpdateRating(a, b, (0, 1));

Console.WriteLine($"A rating: {a.Rating}");
Console.WriteLine($"B rating: {b.Rating}");
Console.WriteLine($"Sum rating: {a.Rating + b.Rating}");

public class Player
{
    public double Rating { get; set; } = 1200;
    public double WinRate { get; init; }

    public Player(double winrate, int rating = 1200)
    {
        if (winrate < 0 || winrate > 1) 
            throw new ArgumentException("bad winrate");

        Rating = rating;
        WinRate = winrate;
    }
}

public class Tester
{
    private int div = 400;
    private int k = 30;
    private int scoreWeight = 10; // Score should increase rating change by 10% of win amount

    public void UpdateRating(Player a, Player b, (int a, int b) s)
    {
        Func<int, int> Outcome = x => (x > 0) ? 1 : 0;

        double QA = Math.Pow(10, a.Rating / 400);
        double QB = Math.Pow(10, b.Rating / 400);

        double WA = Weight(s.a, s.b);
        double WB = Weight(s.a, s.b);

        double changeA = WA * k * (Outcome(s.a - s.b) - Expectation(QA, QB));
        double changeB = WB * k * (Outcome(s.b - s.a) - Expectation(QB, QA));

        a.Rating = a.Rating + changeA;
        b.Rating = b.Rating + changeB;

        double Expectation(double Q1, double Q2)
        {
            return Q1 / (Q1 + Q2);
        }

        double Weight(int x, int y)
        {
            if (Math.Min(x, y) == 0) return 1.1;
            return 1 + (Math.Abs(x - y) / (double)Math.Max(x, y) * scoreWeight);
        }
    }
}


public class SimPlayer
{
    public int Rating { get; set; } = 1200;
}


public class Simulator
{
    public void RunSimulation()
    {
        
    }
}