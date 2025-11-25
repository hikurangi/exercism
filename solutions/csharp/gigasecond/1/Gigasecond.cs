using System;

public static class Gigasecond
{
    private static readonly TimeSpan Giga = TimeSpan.FromSeconds(1000000000);
    public static DateTime Add(DateTime moment)
    {
        return moment.Add(Giga);
    }
}