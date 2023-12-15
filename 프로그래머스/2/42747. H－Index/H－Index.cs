using System;
using System.Linq;

public class Solution 
{
    public int solution(int[] citations) 
    {
        Array.Sort<int>(citations, (i1, i2) => i2.CompareTo(i1));

        for (int i = 0; i < citations.Length; i++)
        {
            if (i >= citations[i]) return i;
        }

        return citations.Length;
    }
}