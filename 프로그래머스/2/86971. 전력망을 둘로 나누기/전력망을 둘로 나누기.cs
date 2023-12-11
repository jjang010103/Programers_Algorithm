using System;
using System.Linq;
using System.Collections.Generic;

public class Solution 
{
    public int solution(int n, int[,] wires) 
    {
        int answer = n;

        Dictionary<int, List<int>> mapDic = new Dictionary<int, List<int>>();

        for (int i = 0; i < wires.GetLength(0); i++)
        {
            AddMapDic(mapDic, wires[i, 0], wires[i, 1]);
            AddMapDic(mapDic, wires[i, 1], wires[i, 0]);
        }

        for (int i = 0; i < wires.GetLength(0); i++)
        {
            var wire1 = wires[i, 0];
            var wire2 = wires[i, 1];

            int wires1Count = GetConnectWireAtMapDic(mapDic, wire1, wire2);
            int wires2Count = GetConnectWireAtMapDic(mapDic, wire2, wire1);

            int diffCount = Math.Abs(wires1Count - wires2Count);

            if (answer > diffCount)
            {
                answer = diffCount;
            }
        }

        return answer;
    }
    
    private void AddMapDic(Dictionary<int, List<int>> mapDic, int key, int value) 
    {
        if (mapDic.TryGetValue(key, out var list))
        {
            list.Add(value);
        }
        else
        {
            mapDic.Add(key, new List<int>() { value });
        }
    }

    private int GetConnectWireAtMapDic(Dictionary<int, List<int>> mapDic, int key, params int[] exceptKeys)
    {
        int value = 1;// 1 = key 본인

        foreach (int wire in mapDic[key])
        {
            if (exceptKeys.Contains(wire)) continue;

            value += GetConnectWireAtMapDic(mapDic, wire, exceptKeys[0], key);
        }

        return value;
    }
}