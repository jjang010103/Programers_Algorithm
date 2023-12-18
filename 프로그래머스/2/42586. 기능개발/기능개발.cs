using System;
using System.Collections.Generic;

public class Solution 
{
    public int[] solution(int[] progresses, int[] speeds) 
    {
        List<int> resultList = new List<int>();

        int maxRemainDate = 0;

        for (int i = 0; i < progresses.Length; i++)
        {
            int remainDate = (int)Math.Ceiling((100 - (double)progresses[i]) / speeds[i]);

            if(maxRemainDate < remainDate)
            {
                maxRemainDate = remainDate;
                resultList.Add(1);
            }
            else
            {
                resultList[resultList.Count - 1] += 1;
            }
        }

        return resultList.ToArray();
    }
}