using System;
using System.Collections.Generic;

public class Robot
{
    public Robot()
    {
        _random = new Random();
        _name = GenerateName();
    }

    // this must be static so all robots register their name
    private static readonly HashSet<string> UsedNames = new HashSet<string>();

    private string _name;
    public string Name { get => _name; }

    private readonly Random _random;
    private char D() => (char)('0' + _random.Next(10));
    private char L() => (char)('A' + _random.Next(26));

    private string GenerateName()
    {
        var name = string.Concat(new List<char> { L(), L(), D(), D(), D() });

        return UsedNames.Add(name)
          ? name
          : GenerateName();
    }

    public void Reset() { _name = GenerateName(); }
}