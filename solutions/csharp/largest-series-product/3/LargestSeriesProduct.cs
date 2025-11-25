using System;
using System.Linq;

public static class LargestSeriesProduct
{
  public static long GetLargestProduct(string digits, int span) =>
    span > digits.Length || span < 0 || digits.Any(c => c > '9' || c < '0')
      ? throw new ArgumentException()
      : Enumerable.Range(0, digits.Length - span + 1)
          .Select(i => digits.Skip(i).Take(span).Aggregate(1, (i, p) => i * (p - '0')))
          .Max();
}