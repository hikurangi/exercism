using System.Linq;
using System.Text.RegularExpressions;

public static class Acronym
{
    private static readonly Regex regex = new Regex(@"[\s_-]+", RegexOptions.Compiled);

    public static string Abbreviate(string phrase) => regex.Split(phrase)
      .Aggregate("", (acronym, w) => acronym += System.Char.ToUpperInvariant(w[0]));
}