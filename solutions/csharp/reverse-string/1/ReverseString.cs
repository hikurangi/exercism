using System;
using System.Collections.Generic;
using System.Linq;

public static class ReverseString
{
    public static string Reverse(string input) => input.ToCharArray().Reverse().Join();

    public static string Join(this IEnumerable<char> chars) => string.Concat(chars); // I don't understand why this doesn't exist already
}