using System.Collections.Generic;

public class Solution 
{
    private List<int[]> MovedList { get; set; }
    
    public int[,] solution(int n)
    {
        MovedList = new List<int[]>();
        Moving(n, 1, 3, 2);

        int[,] answer = new int[MovedList.Count, 2];
        for (int i = 0; i < MovedList.Count; ++i)
        {
            answer[i, 0] = MovedList[i][0];
            answer[i, 1] = MovedList[i][1];
        }

        return answer;
    }

    private void Moving(int n, int start, int end, int sub)
    {
        if (n == 1)
        {
            MovedList.Add(new int[] { start, end });
        }
        else
        {
            Moving(n - 1, start, sub, end);
            MovedList.Add(new int[] { start, end });
            Moving(n - 1, sub, end, start);
        }
    }
}