/*
 * LeetCode Challenge
 * Author: Camilo Lucero
 * Challenge name: Zigzag conversion
 * Description: Convert a string to its representation in a zigzag pattern given a number of rows.
 * URL: https://leetcode.com/problems/zigzag-conversion/
 * Language: C#
 * Status: Solved
 */

string Convert(string s, int numRows)
{
    List<string> list = new List<string>();

    // Create n (numRows) strings and add them to the list.
    for (int i = 0; i < numRows; i++)
    {
        list.Add("");
    }

    // Iterate through each character of s and place it in the correct row (list[row])
    for (int i = 0; i < s.Length; i++)
    {
        if (numRows == 1)
        {
            list[0] += s[i];
            continue;
        }

        int x = numRows - 2;
        int y = i % (numRows + x);

        if (i % (x + numRows) < numRows)
        {
            list[y] += s[i];
        }
        else
        {
            list[numRows + x - y] += s[i];
        }
    }

    return string.Join("", list);
}


// Test cases
List<(string, int, string)> testCases = new List<(string, int, string)>();
testCases.Add(("A", 1, "A"));
testCases.Add(("AB", 1, "AB"));
testCases.Add(("PAYPALISHIRING", 3, "PAHNAPLSIIGYIR"));
testCases.Add(("PAYPALISHIRING", 4, "PINALSIGYAHRPI"));
testCases.Add(("PAYPALISHIRING", 5, "PHASIYIRPLIGAN"));

// Testing
foreach ((string s, int numRows, string expected) in testCases)
{
    string actual = Convert(s, numRows);

    Console.WriteLine($"\nTesting: {s}\nExpected: {expected}\nActual: {actual}");

    Console.WriteLine(expected == actual ? "PASSED" : "FAILED");
}
