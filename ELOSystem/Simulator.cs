using ELOSystem;
using static System.Linq.Enumerable;

public class Simulator
{
    SimPlayer a = new SimPlayer(0.5);
    SimPlayer b = new SimPlayer(0.3);
    ELOCalculator test = new ELOCalculator(400, 30, 10);

    public void run()
    {
        test.UpdateRating(a,b,(1,0));
        Console.WriteLine(a.Rating);
        Console.WriteLine(b.Rating);
    }
    
}