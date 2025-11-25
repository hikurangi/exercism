 using System;
using System.Linq;

public static class DifferenceOfSquares
{
    public static int CalculateSquareOfSum(int max) => max == 1
      ? 1
      : (int)Math.Pow(Enumerable.Range(1, max).Sum(), 2);
        
    public static int CalculateSumOfSquares(int max) => max == 1
      ? 1
      : (int)Enumerable.Range(1, max).Sum(n => Math.Pow(n, 2));

    public static int CalculateDifferenceOfSquares(int max) => CalculateSquareOfSum(max) - CalculateSumOfSquares(max);
 }