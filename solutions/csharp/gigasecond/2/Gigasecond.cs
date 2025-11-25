using System;

public static class Gigasecond
{
    private const int Giga = 1000000000;
    public static DateTime Add(DateTime moment)
    {
        return moment.AddSeconds(Giga);
    }
}