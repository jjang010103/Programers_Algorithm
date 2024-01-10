using System;
using System.Collections.Generic;

public class Solution 
{
    public int solution(int n, int[,] computers) 
    {
        int counter = 0;

        Dictionary<int, List<int>> dic = this.GetConnNetworkDic(computers);

        bool[] visitedArr = new bool[n];

        
        for (int i = 0; i < n; i++)
        {
            if (visitedArr[i]) continue;
            else
            {
                List<int> tempList = dic[i];

                while (tempList.Count != 0)
                {
                    tempList = this.GetConnectComsList(dic, visitedArr, tempList);
                }

                counter++;
            }
        }

        return counter;
    }

    private List<int> GetConnectComsList(Dictionary<int, List<int>> dic, bool[] visitedArr, List<int> beforeComList)
    {
        List<int> tempList = new List<int>();

        foreach (int comIndex in beforeComList)
        {
            foreach (int connectComIndex in dic[comIndex])
            {
                if (visitedArr[connectComIndex]) continue;
                else
                {
                    visitedArr[connectComIndex] = true;

                    tempList.Add(connectComIndex);
                }

            }
        }

        return tempList;
    }

    private Dictionary<int, List<int>> GetConnNetworkDic(int[,] computers)
    {
        var dic = new Dictionary<int, List<int>>();

        for (int i = 0; i < computers.GetLength(0); i++)
        {
            dic.Add(i, new List<int>());

            for (int j = 0; j < computers.GetLength(1); j++)
            {
                if (computers[i, j] == 0 || i == j) continue;

                dic[i].Add(j);
            }
        }

        return dic;
    }
}