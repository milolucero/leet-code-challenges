/*
 * LeetCode Challenge
 * Author: Camilo Lucero
 * Challenge name: Letter Combinations of a Phone Number
 * Description: Given a string containing digits from 2-9 inclusive, return all possible letter combinations that the number could represent. Return the answer in any order.
 * URL: https://leetcode.com/problems/letter-combinations-of-a-phone-number/
 * Language: C#
 * Status: Solved
 */

IList<string> LetterCombinations(string digits)
{
    // Exit point
    if (String.IsNullOrEmpty(digits)) return new List<string>();

    IList<string> result = new List<string>();

    IList<string> current = DigitToLetters(digits[0]);

    IList<string> next = LetterCombinations(digits.Substring(1)).Count == 0 ? new List<string>() { "" } : LetterCombinations(digits.Substring(1));


    for (int i = 0; i < current.Count; i++)
    {
        for (int j = 0; j < next.Count; j++)
        {
            result.Add(current[i] + next[j]);
        }
    }

    return result;
}

// Returns a list of the characters represented on a phone by the given digit.
IList<string> DigitToLetters(char digit)
{
    List<(char numberString, string letters)> dictionary = new List<(char numberString, string letters)>
    {
        ('2', "abc"),
        ('3', "def"),
        ('4', "ghi"),
        ('5', "jkl"),
        ('6', "mno"),
        ('7', "pqrs"),
        ('8', "tuv"),
        ('9', "wxyz"),
    };

    IList<string> result = new List<string>();

    for (int i = 0; i < dictionary.Count; i++)
    {
        if (digit == dictionary[i].numberString)
        {
            foreach (char letter in dictionary[i].letters)
            { 
                result.Add(letter.ToString()); 
            }

            return result;
        }
    }

    throw new Exception("No digit matched the given input.");
}


// Test cases
List<(string, List<string>)> testCases = new List<(string, List<string>)>
{
    ("2", new List<string> {"a","b","c"}),
    ("23", new List<string> {"ad","ae","af","bd","be","bf","cd","ce","cf"}),
    ("", new List<string> {}),
};

// Testing
foreach ((string numberString, IList<string> expected) in testCases)
{
    IList<string> actual = LetterCombinations(numberString);

    Console.WriteLine($"\nTesting: {numberString}\nExpected: {String.Join(", ", expected)}\nActual: {String.Join(", ", actual)}");

    Console.WriteLine(String.Join(", ", actual) == String.Join(", ", expected) ? "PASSED" : "FAILED");
}
