using System.Collections.Generic;
using System.Text.RegularExpressions;
public static class Isogram
{
    private static Regex nonLetterPattern = new Regex("[^a-zA-Z]");
    public static bool IsIsogram(string word)
    {
        var validChars = nonLetterPattern.Replace(word, "").ToLower();

        return validChars.Length == new HashSet<char>(validChars).Count;
    }
}