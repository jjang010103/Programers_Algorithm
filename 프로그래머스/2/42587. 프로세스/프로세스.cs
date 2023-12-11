using System.Linq;
using System.Collections.Generic;

public class Solution 
{
    public int solution(int[] priorities, int location) 
    {
            int answer = 0;

            int maxRank = priorities.Max();

            Dictionary<int, int> rankMapDic = new Dictionary<int, int>();

            for (int i = 0; i < priorities.Count(); i++)
            {
                rankMapDic.Add(i, priorities[i]);
            }

            var queue = new Queue<int>(rankMapDic.Keys);

            while (queue.Count > 0)
            {
                answer++;

                int locationKey = queue.Dequeue();//del

                int rank = rankMapDic[locationKey];

                if (rank < maxRank)
                {
                    queue.Enqueue(locationKey);//add
                    answer--;

                    continue;
                }
                else if (locationKey == location)
                {
                    break;
                }
                else if (rank == maxRank && !queue.Any(i => rankMapDic[i] == maxRank))
                {
                    maxRank = queue.Max(i => rankMapDic[i]);
                }
            }

            return answer;
    }
}