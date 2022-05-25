/*
 * LeetCode Challenge
 * Author: Camilo Lucero
 * Challenge name: Integer to roman
 * Description: Given an integer, convert it to a roman numeral.
 * URL: https://leetcode.com/problems/integer-to-roman/
 * Language: C#
 * Status: Solved
 */

using System.Text.RegularExpressions;

string IntToRoman(int num)
{
    string romanNum = "";

    // Declare a list of tuples with the roman number and its respective value.
    List<(char, int)> romanNumberTable = new List<(char, int)>()
    {
        ('M', 1000),
        ('D', 500),
        ('C', 100),
        ('L', 50),
        ('X', 10),
        ('V', 5),
        ('I', 1)
    };

    // Declare a list of tuples with the special cases and the value that should be used instead.
    List<(string, string)> romanReplacementTable = new List<(string, string)>()
    {
        ("DCCCC", "CM"),
        ("CCCC", "CD"),
        ("LXXXX", "XC"),
        ("XXXX", "XL"),
        ("VIIII", "IX"),
        ("IIII", "IV")
    };

    // Assign the roman value to the given number.
    while (num > 0)
    {
        foreach ((char romanNumber, int romanValue) in romanNumberTable)
        {
            int quotient = num / romanValue;
            int remainder = num % romanValue;

            if (quotient >= 1)
            {
                romanNum += new string(romanNumber, quotient);
                num = remainder;
            }
        }
    }

    // Replace the special cases for its correct value.
    foreach ((string pattern, string replacement) in romanReplacementTable)
    {
        romanNum = Regex.Replace(romanNum, @$"{pattern}", replacement);
    }

    return romanNum;
}


// Test cases
List<(int, string)> testCases = new List<(int, string)>();
testCases.Add((3, "III"));
testCases.Add((14, "XIV"));
testCases.Add((19, "XIX"));
testCases.Add((140, "CXL"));
testCases.Add((58, "LVIII"));
testCases.Add((1994, "MCMXCIV"));

// Testing
foreach ((int num, string expected) in testCases)
{
    string actual = IntToRoman(num);

    Console.WriteLine($"\nTesting: {num}\nExpected: {expected}\nActual: {actual}");

    Console.WriteLine(expected == actual ? "PASSED" : "FAILED");
}
