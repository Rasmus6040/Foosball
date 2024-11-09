namespace ELOSystem;

public class ELOCalculator(int div, int k, int scoreWeight)
{
    public void UpdateRating(SimPlayer a, SimPlayer b, (int a, int b) s)
    {
        Func<int, int> Outcome = x => (x > 0) ? 1 : 0;

        double QA = Math.Pow(10, a.Rating / div);
        double QB = Math.Pow(10, b.Rating / div);

        double WA = Weight(s.a, s.b);
        double WB = Weight(s.a, s.b);

        double changeA = WA * k * (Outcome(s.a - s.b) - Expectation(QA, QB));
        double changeB = WB * k * (Outcome(s.b - s.a) - Expectation(QB, QA));

        a.Rating =+ changeA;
        b.Rating =+ changeB;

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