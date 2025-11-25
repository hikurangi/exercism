using System;
using System.Linq;

public static class ArmstrongNumbers
{
    public static bool IsArmstrongNumber(int number) {
      var chars = number.ToString().ToCharArray();
      var exponent = chars.Length;
      var sum = chars.Sum(c => Math.Pow(c - '0', exponent));
      
      return sum == number;
    }
}