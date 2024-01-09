using System;
using System.Collections.Generic;
using System.Linq;

public class Solution 
{
    public int solution(int n, int[,] computers) 
    {
        Dictionary<int, List<int>> dic = this.GetConnNetworkDic(computers);

        int counter = this.RemoveSingleNetComsAtDic(dic);

        if (dic.Count == 0)
        {
            return counter;
        }
        else
        {
            List<int> tempList = dic[dic.Keys.First()];
            dic.Remove(dic.Keys.First());

            while (dic.Count != 0)
            {
                tempList = this.GetConnectComsList(dic, tempList);

                if (tempList.Count == 0)
                {
                    counter++;

                    tempList = dic[dic.Keys.First()];
                }
            }

            if (dic.Count == 0) counter++;

            return counter;
        }
    }
    
    private List<int> GetConnectComsList(Dictionary<int, List<int>> dic, List<int> beforeComList)
    {
        List<int> tempList = new List<int>();

        foreach (int comIndex in beforeComList)
        {
            if (dic.TryGetValue(comIndex, out var valueList))
            {
                tempList.AddRange(dic[comIndex]);

                dic.Remove(comIndex);
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
                if (i == j) continue;

                if(computers[i, j] == 1)
                {
                    dic[i].Add(j);
                }
            }
        }

        return dic;
    }
    
    private int RemoveSingleNetComsAtDic(Dictionary<int, List<int>> dic)
    {
        int singleNetWorkComCount = 0;

        var singleNetWorkComArr = dic.Where(i => i.Value.Count == 0).ToArray();

        foreach (var item in singleNetWorkComArr)
        {
            dic.Remove(item.Key);

            singleNetWorkComCount++;
        }

        return singleNetWorkComCount;
    }
}