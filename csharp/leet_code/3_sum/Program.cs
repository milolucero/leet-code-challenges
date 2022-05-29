/*
 * LeetCode Challenge
 * Author: Camilo Lucero
 * Challenge name: 3Sum
 * Description: Given an integer array nums, return all the triplets [nums[i], nums[j], nums[k]] such that i != j, i != k, and j != k, and nums[i] + nums[j] + nums[k] == 0.
 * URL: https://leetcode.com/problems/3sum/
 * Language: C#
 * Status: In progress
 */

IList<IList<int>> ThreeSum(int[] nums)
{
    Array.Sort(nums);

    List<int[]> res = new List<int[]>();

    for (int i = 0; i < nums.Length - 2; i++)
    {
        if (i == 0 || (i > 0 && nums[i] != nums[i - 1]))
        {
            int lowIndex = i + 1,
                highIndex = nums.Length - 1,
                sum = 0 - nums[i];

            while (lowIndex < highIndex)
            {
                if (nums[lowIndex] + nums[highIndex] == sum)
                {
                    res.Add(new int[] { nums[i], nums[lowIndex], nums[highIndex] });

                    while (lowIndex < highIndex && nums[lowIndex] == nums[lowIndex + 1])
                    {
                        lowIndex++;
                    }

                    while (lowIndex < highIndex && nums[highIndex] == nums[highIndex - 1])
                    {
                        highIndex--;
                    }

                    lowIndex++;
                    highIndex++;
                }
                else if (nums[lowIndex] + nums[highIndex] < sum)
                {
                    lowIndex++;
                } 
                else
                {
                    highIndex--;
                }
            }
        }
    }

    return (IList<IList<int>>)res;
}

// Test cases
//List<(int[], IList<IList<int>>)> testCases = new List<(int[], IList<IList<int>>)>
//{
//    (new int[] {-1,0,1,2,-1,-4}, new List<IList<int>> { new int[] { -1, -1, 2 }, new int[] { -1, 0, 1 } })
//};

ThreeSum(new int[] { -1, 0, 1, 2, -1, -4 });

// Testing