using System;

public class Solution 
{
    public int[] solution(int[] prices) 
    {
        int[] answer = new int[prices.Length];

        for (int i = 0; i < prices.Length - 1; i++)
        {
            int count = 1;

            for (int j = i + 1; j < prices.Length - 1; j++)
            {
                if (prices[j] < prices[i]) break;
                else count++;
            }

            answer[i] = count;
        }
        
        return answer;
    }
}