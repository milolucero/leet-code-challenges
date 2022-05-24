/*
 * LeetCode Challenge
 * Author: Camilo Lucero
 * Challenge name: Median of two sorted arrays
 * Description: Given two sorted arrays nums1 and nums2 of size m and n respectively, return the median of the two sorted arrays.
 *              The overall run time complexity should be O(log (m+n)).
 * URL: https://leetcode.com/problems/median-of-two-sorted-arrays/
 * Language: C#
 * Status: Solved
 */

// Finds the median of two sorted arrays.
double FindMedianSortedArrays(int[] nums1, int[] nums2)
{
    return FindMedianSortedArray(MergeSort(nums1, nums2));
}

// Merges and sorts two sorted arrays.
int[] MergeSort(int[] nums1, int[] nums2)
{
    int[] mergedNums = new int[nums1.Length + nums2.Length];

    int j = 0; // index for nums1
    int k = 0; // index for nums2

    for (int i = 0; i < mergedNums.Length; i++)
    {
        int smallest;

        if (j == nums1.Length)
        {
            smallest = nums2[k];
            k++;
        }
        else if (k == nums2.Length)
        {
            smallest = nums1[j];
            j++;
        }
        else if (nums1[j] <= nums2[k])
        {
            smallest = nums1[j];
            j++;
        }
        else
        {
            smallest = nums2[k];
            k++;
        }

        mergedNums[i] = smallest;
    }

    return mergedNums;
}

// Finds the median of a sorted array.
double FindMedianSortedArray(int[] nums)
{
    double median;
    double midPoint = (nums.Length - 1) / 2.0;

    if (midPoint % 1 == 0)
    {
        median = nums[(int)midPoint];
    }
    else
    {
        median = (nums[(int)Math.Floor(midPoint)] + nums[(int)Math.Ceiling(midPoint)]) / 2.0;
    }

    return median;
}


// Test cases
TestCase[] TestCases =
{
    new TestCase(new int[] { 1, 3 }, new int[] { 2 }, 2.0),
    new TestCase(new int[] { 1, 2 }, new int[] { 3, 4 }, 2.5),
    new TestCase(new int[] { 5 }, new int[] { 3, 4 }, 4.0)
};

foreach (TestCase testCase in TestCases)
{
    double actual = FindMedianSortedArrays(testCase.nums1, testCase.nums2);

    Console.WriteLine($"\nTest case: \"[{string.Join(", ", testCase.nums1)}], [{string.Join(", ", testCase.nums2)}]\"\nExpected: {testCase.expected}\nActual: {actual}");

    Console.WriteLine(testCase.expected == actual ? "PASSED" : "FAILED");
}

class TestCase
{
    public int[] nums1;
    public int[] nums2;
    public double expected;

    public TestCase(int[] nums1, int[] nums2, double expected)
    {
        this.nums1 = nums1;
        this.nums2 = nums2;
        this.expected = expected;
    }
}
