using System;
using System.Text.RegularExpressions;

static class LogLine
{   
    private static string GetLevel(string log) => new Regex(@"\[(?<level>\w+)\]").Match(log).Groups["level"].Value.ToLowerInvariant();
    private static string GetMessage(string log) => new Regex(@"\s+(?<message>[\w\s]+)\s*").Match(log).Groups["message"].Value.Trim();

    public static string Message(string logLine) => GetMessage(logLine);
    public static string LogLevel(string logLine) => GetLevel(logLine);
    public static string Reformat(string logLine) => $"{GetMessage(logLine)} ({GetLevel(logLine)})";
}