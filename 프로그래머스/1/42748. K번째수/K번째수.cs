using System;

public class Solution 
{
    public int[] solution(int[] array, int[,] commands) 
    {
        int[] answer = new int[commands.GetLength(0)];

        for (int index = 0; index < answer.Length; index++)
        {
            int i = commands[index, 0] - 1;
            int j = commands[index, 1] - 1;
            int k = commands[index, 2] - 1;

            int arrLen = j - i + 1;

            int[] tempArray = new int[arrLen];

            Array.Copy(array, i, tempArray, 0, arrLen);

            Array.Sort(tempArray);

            answer[index] = tempArray[k];
        }

        return answer;
    }
}