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
    if (String.IsNullOrEmpty(digits)) return new List<string>() {};

    IList<string> result = new List<string>();

    string currentLetters = DigitToLetters(digits[0]);

    for (int i = 0; i < currentLetters.Length; i++)
    {
        result = LetterCombinations(digits.Substring(i + 1));
    }

    //// Use recursion
    //for (int i = 0; i < digits.Length; i++)
    //{
    //    foreach (string letters in LetterCombinations(digits.Substring(i + 1)))
    //    {
    //        string currentLetters = DigitToLetters(digits[0]);

    //        foreach (char letter in currentLetters)
    //        {
    //            result.Add(letter.ToString());
    //        }
    //    }
    //}

    return result;
}

// Returns the letters represented on a phone by the given digit.
string DigitToLetters(char digit)
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
        ('9', "wzyz"),
    };

    for (int i = 0; i < dictionary.Count; i++)
    {
        if (digit == dictionary[i].numberString)
        {
            return dictionary[i].letters;
        }
    }

    throw new Exception("No digit matched the given input.");
}


// Test cases
List<(string, List<string>)> testCases = new List<(string, List<string>)>
{
    ("2", new List<string> {"a","b","c"}),
    //("23", new List<string> {"ad","ae","af","bd","be","bf","cd","ce","cf"}),
    //("", new List<string> {}),
};

// Testing
foreach ((string numberString, IList<string> expected) in testCases)
{
    IList<string> actual = LetterCombinations(numberString);

    Console.WriteLine($"\nTesting: {numberString}\nExpected: {String.Join(", ", expected)}\nActual: {String.Join(", ", actual)}");

    Console.WriteLine(String.Join(", ", actual) == String.Join(", ", expected) ? "PASSED" : "FAILED");
}
