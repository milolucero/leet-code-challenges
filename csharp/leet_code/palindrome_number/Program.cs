/*
 * LeetCode Challenge
 * Author: Camilo Lucero
 * Challenge name: Palindrome number
 * Description: Given an integer x, return true if x is palindrome integer.
 * URL: https://leetcode.com/problems/palindrome-number/
 * Language: C#
 * Status: Solved
 */

bool IsPalindrome(int x)
{
    string s = x.ToString();
    string reversed = "";

    for (int i = 0; i < s.Length; i++)
    {
        reversed = s[i] + reversed;
    }

    return s == reversed;
}


// Test cases
List<(int, bool)> testCases = new List<(int, bool)>();
testCases.Add((10, false));
testCases.Add((121, true));
testCases.Add((-121, false));

// Testing
foreach ((int x, bool expected) in testCases)
{
    bool actual = IsPalindrome(x);

    Console.WriteLine($"\nTesting: {x}\nExpected: {expected}\nActual: {actual}");

    Console.WriteLine(expected == actual ? "PASSED" : "FAILED");
}
