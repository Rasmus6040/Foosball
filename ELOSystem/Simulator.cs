namespace ELOSystem;

public class Simulator
{
    private readonly ELOCalculator _eloCalculator = new();

    private void CreateSimMatch(SimPlayer simA, SimPlayer simB, (int ScoreA, int ScoreB) scores)
    {
        _eloCalculator.UpdateRatings(simA.Player, simB.Player, scores);
    }
    
    public List<SimPlayer> Simulate(int n, params double[] winRates)
    {
        var rand = new Random();
        int count = winRates.Count();
        var players = winRates.Select(wr => new SimPlayer(wr)).ToList();

        int[] indices = Enumerable.Range(0, count).ToArray();

        for (int i = 0; i < n; i++)
        {
            rand.Shuffle(indices);

            for (int j = 0; j < count - 1; j += 2)
            {
                SimPlayer a = players[indices[j]];
                int aw = (int)(a.WinRate * 100);

                SimPlayer b = players[indices[j + 1]];
                int bw = (int)(b.WinRate * 100);

                var flip = rand.Next(0, aw + bw);
                var result = (1, 0);
                if (flip > aw) result = (0, 1);

                CreateSimMatch(a, b, result);
            }
        }
        return players;
    }
}