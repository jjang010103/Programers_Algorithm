using System;

public class Solution 
{
    public int[] solution(int[] prices) 
    {
        int[] answer = new int[prices.Length];

        for (int i = 0; i < prices.Length - 1; i++)
        {
            for (int j = i + 1; j < prices.Length; j++)
            {
                answer[i]++;

                if (prices[j] < prices[i]) break;
            }
        }

        return answer;
    }
}