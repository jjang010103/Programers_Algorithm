using System.Collections.Generic;
using System.Linq;

public class Solution 
{
    public int solution(int bridge_length, int weight, int[] truck_weights) 
    {
        int totalTime = 0;

        int sumWeight = 0;

        Queue<int> trucks = new Queue<int>(truck_weights);

        Queue<int> bridge = new Queue<int>();

        while (trucks.Count != 0)
        {
            if (bridge.Count != 0 && bridge.Count % bridge_length == 0)
            {
                sumWeight -= bridge.Dequeue();
            }

            if (trucks.TryPeek(out int temp) && sumWeight + temp <= weight)
            {
                bridge.Enqueue(trucks.Dequeue());

                sumWeight += temp;
            }
            else
            {
                bridge.Enqueue(0);
            }

            totalTime++;
        };

        return totalTime + bridge_length;
    }
}