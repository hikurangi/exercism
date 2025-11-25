using System;
using System.Linq;
using System.Text.RegularExpressions;

public class PhoneNumber
{
    private const string phoneNumberPattern = @"^1?([2-9]\d\d[2-9][\d]{6})$";
    
    public static string Clean(string phoneNumber)
    {
        var digitsOnly = string.Concat(phoneNumber.Where(char.IsDigit));
        var numberMatch = Regex.Match(digitsOnly, phoneNumberPattern);
        var numberSansCountryCode = numberMatch.Groups[1].ToString();

        return numberMatch.Success ? numberSansCountryCode : throw new ArgumentException();
    }
}