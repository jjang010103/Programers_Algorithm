using System;

public class Solution 
{
    public int solution(int n) 
    {
        int answer = 0;

        for (int i = 0; i < n; i++)
        {
            answer++;

            while (answer % 3 == 0 || answer.ToString().Contains("3"))
            {
                answer++;
            }
        }

        return answer;
    }
}