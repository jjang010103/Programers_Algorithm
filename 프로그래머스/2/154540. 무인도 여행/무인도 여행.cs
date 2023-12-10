using System;
using System.Collections.Generic;

public class Solution {
    public int[] solution(string[] maps) {
        List<int> foods = new List<int>();
        int[] answer = new int[] {};
        int y = maps.Length;
        int x = maps[0].Length;

        int[,] mapFood = new int[y,x];

        for(int i=0;i<y;i++)
        {
            for(int j=0;j<x;j++)
            {
                if(maps[i][j] == 'X')
                {
                    mapFood[i,j] = 0;
                } else
                {
                    mapFood[i,j] = maps[i][j] - '0';
                }
            }
        }

        for(int i=0;i<y;i++)
        {
            for(int j=0;j<x;j++)
            {
                if(mapFood[i,j] > 0)
                {
                    int food = FindFood(mapFood, j, i);
                    foods.Add(food);
                }
            }
        }
        foods.Sort();
        if(foods.Count == 0)
        {
            answer = new int[1];
            answer[0] = -1;
        } else
        {
            answer = foods.ToArray();
        }


        return answer;
    }

    int FindFood(int[,] mapFood, int x, int y)
    {
        int countFood = mapFood[y,x];
        mapFood[y,x] = 0;

        if(x > 0) if(mapFood[y,x-1] > 0) countFood += FindFood(mapFood, x-1, y);
        if(y > 0) if(mapFood[y-1,x] > 0) countFood += FindFood(mapFood, x, y-1);

        if(x < mapFood.GetLength(1)-1) if(mapFood[y,x+1] > 0) countFood += FindFood(mapFood, x+1, y);
        if(y < mapFood.GetLength(0)-1) if(mapFood[y+1,x] > 0) countFood += FindFood(mapFood, x, y+1);

        return countFood;
    }

}