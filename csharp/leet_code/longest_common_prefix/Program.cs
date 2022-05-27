/*
 * LeetCode Challenge
 * Author: Camilo Lucero
 * Challenge name: Longest common prefix
 * Description: Find the longest common prefix string amongst an array of strings.
 * URL: https://leetcode.com/problems/longest-common-prefix/
 * Language: C#
 * Status: Solved
 */

string LongestCommonPrefix(string[] strs)
{
    string longestCommonPrefix = "";

    for (int  i = 0; true; i++)
    {
        for (int j = 0; j < strs.Length; j++)
        {
            if (strs[j].Length <= i || strs[0][i] != strs[j][i])
            {
                return longestCommonPrefix;
            }

            if (j == strs.Length - 1)
            {
                longestCommonPrefix += strs[0][i];
            }
        }
    }
}


// Test cases
List<(string[], string)> testCases = new List<(string[], string)>
{
    (new[] { "" }, ""),
    (new[] { "a" }, "a"),
    (new[] { "", "" }, ""),
    (new[] { "flower", "flow", "flight" }, "fl"),
    (new[] { "dog","racecar","car" }, ""),
};

// Testing
foreach ((string[] strs, string expected) in testCases)
{
    string actual = LongestCommonPrefix(strs);

    Console.WriteLine($"\nTesting: [{String.Join(", ", strs)}]\nExpected: {expected}\nActual: {actual}");

    Console.WriteLine(expected == actual ? "PASSED" : "FAILED");
}
