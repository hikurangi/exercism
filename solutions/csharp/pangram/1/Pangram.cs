using System;
using System.Collections.Generic;
using System.Linq;

public static class Pangram
{
  private static char[] alphabet = {
    'a',
    'b',
    'c',
    'd',
    'e',
    'f',
    'g',
    'h',
    'i',
    'j',
    'k',
    'l',
    'm',
    'n',
    'o',
    'p',
    'q',
    'r',
    's',
    't',
    'u',
    'v',
    'w',
    'x',
    'y',
    'z'
  };

  public static bool IsPangram(string input)
  {
    return alphabet.All(letter => input.ToLower().Contains(letter));
  }
}
