using System;

public class Solution {
    public int[] solution(string[] wallpaper) 
    {
        int[] answer = new int[] { 50, 50, 0, 0 };

        for (int i = 0; i < wallpaper.Length; i++)
        {
            for (int j = 0; j < wallpaper[i].Length; j++)
            {
                if (wallpaper[i][j] == '#')
                {
                    if(answer[0] > i)
                    {
                        answer[0] = i;
                    }

                    if (answer[1] > j)
                    {
                        answer[1] = j;
                    }

                    if (answer[2] < i)
                    {
                        answer[2] = i;
                    }

                    if (answer[3] < j)
                    {
                        answer[3] = j;
                    }
                }
            }
        }

        answer[2] += 1;
        answer[3] += 1;

        return answer;
    }
}