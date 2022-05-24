/*
 * LeetCode Challenge
 * Author: Camilo Lucero
 * Challenge name: Longest palindromic substring
 * Description: Given a string s, return the longest palindromic substring in s.
 * URL: https://leetcode.com/problems/longest-palindromic-substring/
 * Language: C#
 * Status: Solved
 */

string LongestPalindrome(string s)
{
    string longestPalindrome = "";

    for (int currentLength = s.Length; currentLength > 0; currentLength--)
    {
        for (int i = 0; i <= s.Length - currentLength; i++)
        {
            string substring = s.Substring(i, currentLength);

            if (IsPalindrome(substring))
            {
                return substring;
            }
        }
    }

    return longestPalindrome;
}

// Returns true if the given string is a palindrome; otherwise, false.
bool IsPalindrome(string s)
{
    for (int i = 0; i < s.Length; i++)
    {
        if (s[i] != s[s.Length - 1 - i])
        {
            return false;
        }
    }

    return true;
}


// Test cases
Tuple<string, string>[] testCases =
{
    Tuple.Create("babad", "bab"),
    Tuple.Create("cbbd", "bb"),
    Tuple.Create("bananas", "anana"),
    Tuple.Create("civilwartestingwhetherthatnaptionoranynartionsoconceivedandsodedicatedcanlongendureWeareqmetonagreatbattlefiemldoftzhatwarWehavecometodedicpateaportionofthatfieldasafinalrestingplaceforthosewhoheregavetheirlivesthatthatnationmightliveItisaltogetherfangandproperthatweshoulddothisButinalargersensewecannotdedicatewecannotconsecratewecannothallowthisgroundThebravelmenlivinganddeadwhostruggledherehaveconsecrateditfaraboveourpoorponwertoaddordetractTgheworldadswfilllittlenotlenorlongrememberwhatwesayherebutitcanneverforgetwhattheydidhereItisforusthelivingrathertobededicatedheretotheulnfinishedworkwhichtheywhofoughtherehavethusfarsonoblyadvancedItisratherforustobeherededicatedtothegreattdafskremainingbeforeusthatfromthesehonoreddeadwetakeincreaseddevotiontothatcauseforwhichtheygavethelastpfullmeasureofdevotionthatweherehighlyresolvethatthesedeadshallnothavediedinvainthatthisnationunsderGodshallhaveanewbirthoffreedomandthatgovernmentofthepeoplebythepeopleforthepeopleshallnotperishfromtheearth", "ranynar"),
};

foreach ((string testCase, string expected) in testCases)
{
    string actual = LongestPalindrome(testCase);

    Console.WriteLine($"\nTest case: \"{testCase}\"\nExpected: {expected}\nActual: {actual}");

    Console.WriteLine(expected == actual ? "PASSED" : "FAILED");
}
