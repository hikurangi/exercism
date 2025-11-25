using System;
using System.Collections.Generic;

public class Robot
{
    public Robot()
    {
        _random = new Random();
        _name = GenerateName();
    }

    private string _name;

    public string Name { get => _name; }

    private static readonly HashSet<string> Used = new HashSet<string>();

    private readonly Random _random;

    private string GenerateName()
    {
        var newName = string.Concat(new List<char> { L(), L(), D(), D(), D() });

        return Used.Add(newName)
          ? newName
          : GenerateName();
    }


    private char D() => (char)('0' + _random.Next(10));
    private char L() => (char)('A' + _random.Next(26));

    public void Reset() { _name = GenerateName(); }
}