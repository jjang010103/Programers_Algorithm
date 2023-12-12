using System;
using System.Collections.Generic;

public class Solution 
{
    public int[] solution(int n) 
    {
        int index = 1;

        int[,] map = new int[n,n];//줄 = y/칸 = x

        int min_x = 0;
        int min_y = 0;
        int max_x = n - 1;
        int max_y = n - 1;

        while(min_x <= max_x && min_x <= max_y)
        {
            for (int i = min_y; i <= max_y; i++)
            {
                map[i, min_x] = index++;
            }
            min_x++;
            min_y++;

            for (int i = min_x; i <= max_x; i++)
            {
                map[max_y, i] = index++;
            }
            max_y--;
            max_x--;

            int tempY = max_y;
            for (int i = max_x; i >= min_x; i--)
            {
                map[tempY--, i] = index++;
            }
            max_x--;
            min_y++;
        }

        List<int> list = new List<int>();

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if(map[i, j] != 0)
                {
                    list.Add(map[i, j]);
                }
                //Console.Write(map[i, j].ToString("D2") + " ");
            }

            //Console.WriteLine();
        }

        return list.ToArray();
    }
}