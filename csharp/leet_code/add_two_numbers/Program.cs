/*
 * LeetCode Challenge
 * Author: Camilo Lucero
 * Challenge name: Add two numbers
 * Description: You are given two non-empty linked lists representing two non-negative integers.
 *              The digits are stored in reverse order, and each of their nodes contains a single digit.
 *              Add the two numbers and return the sum as a linked list.
 * URL: https://leetcode.com/problems/add-two-numbers/
 * Language: C#
 * Status: Solved
 */

using System;
using System.Numerics;

// Returns the sum of two singly-linked lists' values.
ListNode AddTwoNumbers(ListNode l1, ListNode l2)
{
    return NumToList(ListToNum(l1) + ListToNum(l2));
}

// Parses a singly-linked list into an integer.
BigInteger ListToNum(ListNode list)
{
    string result = "";

    while (true)
    {
        if (list is null)
        {
            break;
        }

        result = list.val.ToString() + result;
        list = list.next;
    }

    return BigInteger.Parse(result);
}

// Parses an intenger into a singly-linked list.
ListNode NumToList(BigInteger num)
{
    string numberString = num.ToString();

    ListNode list = new ListNode();
    ListNode firstNode = list;

    for (int i = numberString.Length - 1; i >= 0; i--)
    {
        list.val = Int32.Parse(numberString[i].ToString());

        if (i != 0)
        {
            list.next = new ListNode();
        }

        list = list.next;
    }

    return firstNode;
}

// Returns a node containing the given integer.
ListNode NumToNode(int num)
{
    ListNode node = new ListNode(num);

    return node;
}


/**
 * Definition for singly-linked list.
 */
public class ListNode
{
    public int val;
    public ListNode next;

    public ListNode(int val = 0, ListNode? next = null)
    {
        this.val = val;
        this.next = next;
    }
}
