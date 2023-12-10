using System;
using System.Collections.Generic;
using System.Linq;

public class Solution 
{
        public int solution(int n, int[,] edge)
        {
            int answer = -1;

            var dic = GetConvertDic(edge).ToList();

            List<int> usedKeyList = new List<int>() { 1 };
            List<int> keyList = new List<int>() { 1 };

            while (keyList.Count != 0)
            {
                answer = keyList.Count();

                var findResults = dic.Where(i => keyList.Contains(i.Key))
                                    .SelectMany(i => i.Value).Distinct()
                                    .Where(i => !usedKeyList.Contains(i))
                                    .ToArray();

                keyList.Clear();
                keyList.AddRange(findResults);
                usedKeyList.AddRange(findResults);
            }

            return answer;
        }

        private Dictionary<int, List<int>> GetConvertDic(int[,] edge)
        {
            var dic = new Dictionary<int, List<int>>();

            for (int i = 0; i < edge.GetLength(0); i++)
            {
                AddDic(dic, edge[i, 0], edge[i, 1]);
                AddDic(dic, edge[i, 1], edge[i, 0]);
            }

            return dic;
        }
    
        private void AddDic(Dictionary<int, List<int>> dic, int key, int val)
        {
            if (dic.TryGetValue(key, out var list))
            {
                list.Add(val);
            }
            else
            {
                dic.Add(key, new List<int>() { val });
            }
        }
}
