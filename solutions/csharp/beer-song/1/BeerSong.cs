using System;
using System.Collections.Generic;
using System.Linq;

public static class BeerSong
{
    private static string Plural(string singular, int count) => count == 1 ? singular : singular + "s";

    private static string Verse(int n) => n switch
    {
        > 1 => $"{n} {Plural("bottle", n)} of beer on the wall, {n} {Plural("bottle", n)} of beer.\nTake one down and pass it around, {n - 1} {Plural("bottle", n - 1)} of beer on the wall.",
        1 => $"1 bottle of beer on the wall, 1 bottle of beer.\nTake it down and pass it around, no more bottles of beer on the wall.",
        0 => $"No more bottles of beer on the wall, no more bottles of beer.\nGo to the store and buy some more, 99 bottles of beer on the wall.",
        var i => throw new ArgumentOutOfRangeException($"'{i}' is an invalid number of beers on the wall")
    };


    public static string Recite(int startBottles, int takeDown) => Enumerable
      .Range(startBottles - takeDown + 1, takeDown)
      .Reverse()
      .Select(Verse)
      .Join("\n\n");
}

public static class AWeirdOmissionFromLINQ {
    public static string Join(this IEnumerable<string> s, string separator = "") => String.Join(separator, s);
}