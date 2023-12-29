using System;
using System.Collections.Generic;
using System.Linq;

public class Solution 
{
    public int solution(int[] elements) 
    {
        var runArr = elements.Concat(elements).ToArray();

        List<int> resultList = new List<int>(elements);

        for (int i = 2; i <= elements.Length; i++)
        {
            for (int j = 0; j < runArr.Length; j++)
            {
                if (elements.Length <= j)
                {
                    break;
                }
                else
                {
                    int tempVal = 0;
                    for (int k = j; k < j + i; k++)
                    {
                        tempVal += runArr[k];
                    }

                    resultList.Add(tempVal);
                }
            }
        }

        return resultList.Distinct().Count();
    }
}