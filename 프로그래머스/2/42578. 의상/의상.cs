using System.Collections.Generic;

public class Solution 
{
    public int solution(string[,] clothes) 
    {
        var clothDic = this.GetClothDic(clothes);

        int answer = 0;

        foreach (var item in clothDic)
        {
            int tempVal = item.Value.Count + 1;

            if (answer == 0) answer = tempVal;
            else answer *= tempVal;
        }

        return answer - 1;
    }
    
    private Dictionary<string, List<string>> GetClothDic(string[,] clothes)
    {
        var dic = new Dictionary<string, List<string>>();

        for (int i = 0; i < clothes.GetLength(0); i++)
        {
            if (!dic.TryAdd(clothes[i, 1], new List<string>() { clothes[i, 0] }))
            {
                dic[clothes[i, 1]].Add(clothes[i, 0]);
            }
        }

        return dic;
    }
}