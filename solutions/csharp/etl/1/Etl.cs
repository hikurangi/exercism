using System.Collections.Generic;
using System.Linq;

public static class Etl
{
    public static Dictionary<string, int> Transform(Dictionary<int, string[]> old) => old
      .SelectMany(e => e.Value.Select(v => (v.ToLowerInvariant(), e.Key)))
      .ToDictionary(v => v.Item1, v => v.Item2);
}