using System;
using System.Collections.Generic;
using System.Linq;

public class Solution 
{
    public int solution(int[] elements) 
    {
        var runArr = elements.Concat(elements).ToArray();

        List<int> resultList = new List<int>(elements);

        for (int i = 0; i < elements.Length - 1; i++)
        {
            for (int j = 0; j < elements.Length; j++)
            {
                int tempVal = resultList[i * elements.Length + j] + runArr[j + 1 + i];
                resultList.Add(tempVal);
            }
        }

        return resultList.Distinct().Count();
    }
}