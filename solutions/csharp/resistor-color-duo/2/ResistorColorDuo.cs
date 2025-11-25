using System;
using System.Linq;

public enum Colors { Black = 0, Brown = 1, Red = 2, Orange = 3, Yellow = 4, Green = 5, Blue = 6, Violet = 7, Grey = 8, White = 9 }

public static class ResistorColorDuo
{
    public static int Value(string[] colors) =>
      int.Parse(colors.Take(2).Aggregate("", (s, color) => s + (int)Enum.Parse<Colors>(color, true)));
}
