using System;
using System.Linq;

public static class Grains
{
    public static ulong Square(int n) => n > 0 && n < 65
      ? (ulong)Math.Pow(2, n - 1)
      : throw new ArgumentOutOfRangeException();

    public static ulong Total() => (ulong)(from number in Enumerable.Range(1, 64) select (long)Square(number)).ToList().Sum();
}