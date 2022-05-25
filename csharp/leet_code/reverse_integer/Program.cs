/*
 * LeetCode Challenge
 * Author: Camilo Lucero
 * Challenge name: Reverse integer
 * Description: Given a signed 32-bit integer x, return x with its digits reversed. 
 * If reversing x causes the value to go outside the signed 32-bit integer range [-231, 231 - 1], then return 0.
 * URL: https://leetcode.com/problems/reverse-integer/
 * Language: C#
 * Status: Solved
 */

int Reverse(int x)
{
    int reversedX;

    string reversedStringX = GetReversedString(x.ToString());
    int.TryParse(reversedStringX, out reversedX);

    return reversedX;
}

// Takes a string representing an integer and returns it reversed, taking the sign into account.
string GetReversedString(string s)
{
    string reversed = "";

    for (int i = 0; i < s.Length; i++)
    {
        // If the given string starts with "-" (is a negative number), modify the last iteration to place the sign at the beginning of the reversed string.
        if (i == s.Length - 1 && s[0] == '-')
        {
            reversed = s[i] + reversed.Substring(0, reversed.Length - 1);
            reversed = '-' + reversed;
            continue;
        }

        reversed = s[i] + reversed;
    }

    return reversed;
}


// Test cases
List<(int, int)> testCases = new List<(int, int)>();
testCases.Add((123, 321));
testCases.Add((-123, -321));
testCases.Add((120, 21));
testCases.Add((1000000009, 0));

// Testing
foreach ((int x, int expected) in testCases)
{
    int actual = Reverse(x);

    Console.WriteLine($"\nTesting: {x}\nExpected: {expected}\nActual: {actual}");

    Console.WriteLine(expected == actual ? "PASSED" : "FAILED");
}
