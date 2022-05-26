/*
 * LeetCode Challenge
 * Author: Camilo Lucero
 * Challenge name: Roman to integer
 * Description: Given an roman numeral, convert it to an integer.
 * URL: https://leetcode.com/problems/roman-to-integer/
 * Language: C#
 * Status: Solved
 */

using System.Text.RegularExpressions;

int RomanToInt(string s)
{
    int result = 0;

    // Normalize special cases
    s = Regex.Replace(s, @"IV", "IIII");
    s = Regex.Replace(s, @"IX", "VIIII");
    s = Regex.Replace(s, @"XL", "XXXX");
    s = Regex.Replace(s, @"XC", "LXXXX");
    s = Regex.Replace(s, @"CD", "CCCC");
    s = Regex.Replace(s, @"CM", "DCCCC");

    // Convert each character to its int equivalent
    for (int i = 0; i < s.Length; i++)
    {
        result += RomanCharToInt(s[i]);
    }

    return result;
}

// Takes a single character Roman number and returns its equivalent integer value, or -1 if the given char was not a Roman number.
int RomanCharToInt(char c)
{
    // Declare number-value pairs
    char[] romanNumbers = { 'I', 'V', 'X', 'L', 'C', 'D', 'M' };
    int[] romanValues = { 1, 5, 10, 50, 100, 500, 1000 };

    for (int i = 0; i < romanNumbers.Length; i++)
    {
            if (c == romanNumbers[i]) return romanValues[i];
    }

    return -1;
}


// Test cases
List<(string, int)> testCases = new List<(string, int)>
{
    ("III", 3),
    ("XIV", 14),
    ("XXIX", 29),
    ("CXL", 140),
    ("CCXC", 290),
    ("CD", 400),
    ("CM", 900),
    ("LVIII", 58),
    ("MCMXCIV", 1994),
};

// Testing
foreach ((string s, int expected) in testCases)
{
    int actual = RomanToInt(s);

    Console.WriteLine($"\nTesting: {s}\nExpected: {expected}\nActual: {actual}");

    Console.WriteLine(expected == actual ? "PASSED" : "FAILED");
}
