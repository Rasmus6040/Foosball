namespace ELOSystem;

public class KValues
{
    private List<(int Rating, int K)> Ks { get; init; }

    public KValues(int defaultK, params (int, int)[] args)
    {
        Ks = new List<(int, int)> { (0, defaultK) };
        foreach (var arg in args)
            Ks.Add(arg);
        Ks.Sort((x, y) => x.Rating - y.Rating);
    }

    public int GetK(double rating)
    {
        return Ks.First(x => x.Rating < rating).K;
    }
}
