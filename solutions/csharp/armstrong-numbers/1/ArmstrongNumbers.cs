using System;
using System.Linq;

public static class ArmstrongNumbers
{
    public static bool IsArmstrongNumber(int number) {
      var chars = number.ToString().ToCharArray();
      var exponent = chars.Length;
      var sum = chars.Aggregate(0, (t, n) => t + (int)Math.Pow(n - '0', exponent));
      
      return sum == number;
    }
}