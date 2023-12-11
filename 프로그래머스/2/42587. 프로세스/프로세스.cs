using System.Collections.Generic;
using System.Linq;

public class Solution {
    public int solution(int[] priorities, int location)
    {
        int answer = 0;

        var queue = new Queue<KeyValuePair<int, int>>();

        for (int i = 0; i < priorities.Count(); i++)
        {
            queue.Enqueue(new KeyValuePair<int, int>(i, priorities[i]));
        }

        int maxRank = queue.Max(i => i.Value);

        while (queue.Count > 0)
        {
            answer++;

            var queueItem = queue.Dequeue();//del

            if (queueItem.Value < maxRank)
            {
                queue.Enqueue(queueItem);//add
                answer--;

                continue;
            }
            else if (queueItem.Key == location)
            {
                break;
            }
            else if (queueItem.Value == maxRank)
            {
                maxRank = queue.Max(i => i.Value);
            }
        }

        return answer;       
    }
}