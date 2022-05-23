/*
 * LeetCode Challenge
 * Author: Camilo Lucero
 * Challenge name: Longest Substring Without Repeating Characters
 * Description: Given a string s, find the length of the longest substring without repeating characters.
 * URL: https://leetcode.com/problems/longest-substring-without-repeating-characters/
 * Language: C#
 * Status: Solved
 */

int LengthOfLongestSubstring(string s)
{
    HashSet<char> longestSubstringSet = new HashSet<char>();

    for (int i = 0; longestSubstringSet.Count < s.Length - i; i++)
    {
        HashSet<char> currentSubstringSet = new HashSet<char>();
        int counter = 0;

        do
        {
            currentSubstringSet.Add(s[i + counter]);
            counter++;
        } while (s.Length > (i + counter) && !currentSubstringSet.Contains(s[i + counter]));

        if (currentSubstringSet.Count > longestSubstringSet.Count)
        {
            longestSubstringSet = currentSubstringSet;
        }
    }

    return longestSubstringSet.Count;
}


// Test cases:
Tuple<string, int>[] testCases =
{
    Tuple.Create("abcabcbb", 3),
    Tuple.Create("bbbbb", 1),
    Tuple.Create("pwwkew", 3),
    Tuple.Create(" ", 1),
};

foreach ((string testCase, int expected) in testCases)
{
    int actual = LengthOfLongestSubstring(testCase);

    Console.WriteLine($"\nTest case: \"{testCase}\"\nExpected: {expected}\nActual: {actual}");

    Console.WriteLine(expected == actual ? "PASSED" : "FAILED");
}
