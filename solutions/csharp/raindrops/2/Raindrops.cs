using System.Collections.Generic;
using System.Linq;

public static class Raindrops
{
    private static IEnumerable<(int, string)> _drops = new List<(int, string)>{
      (3, "Pling"),
      (5, "Plang"),
      (7, "Plong")
    };

    public static string Convert(int number)
    {
        var processed = _drops.Aggregate("", (s, i) => number % i.Item1 == 0 ? s + i.Item2 : s);
        return processed.Length == 0 ? number.ToString() : processed;
    }
}