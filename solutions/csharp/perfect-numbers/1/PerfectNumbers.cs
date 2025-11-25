using System;
using System.Linq;

public enum Classification
{
    Perfect,
    Abundant,
    Deficient
}

public static class PerfectNumbers
{
    private static int AliquotSum (int number) => Enumerable.Range(1, (number - 1))
          .Aggregate(0, (total, n) => number % n == 0 ? n + total : total);
    public static Classification Classify(int number)
    {
        var aliquotSum = AliquotSum(number);

        return aliquotSum > number
          ? Classification.Abundant
          : aliquotSum == number
          ? Classification.Perfect
          : Classification.Deficient;
    }
}
