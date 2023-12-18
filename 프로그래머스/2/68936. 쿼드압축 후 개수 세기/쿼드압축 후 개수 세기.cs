using System;

public class Solution 
{
    public int[] solution(int[,] arr) 
    {
        int count_0 = 0;
        int count_1 = 0;

        for (int boxIndex = arr.GetLength(0); boxIndex > 0; boxIndex /= 2)//자를 갯수
        {
            for (int startIndex_Y = 0 * boxIndex; startIndex_Y < arr.GetLength(0); startIndex_Y += boxIndex)
            {
                for (int startIndex_X = 0 * boxIndex; startIndex_X < arr.GetLength(0); startIndex_X += boxIndex)
                {
                    int numZipIndex = GetWhichNumberZip(startIndex_Y, startIndex_X, boxIndex, arr);

                    if (numZipIndex == 0) count_0++;
                    else if (numZipIndex == 1) count_1++;
                }
            }
        }

        return new int[] { count_0, count_1 };
    }
    
    private int GetWhichNumberZip(int startIndex_Y, int startIndex_X, int boxIndex, int[,] arr)
    {
        int count_0 = 0;
        int count_1 = 0;

        for (int k = startIndex_Y; k < startIndex_Y + boxIndex; k++)//Y
        {
            for (int l = startIndex_X; l < startIndex_X + boxIndex; l++)//X
            {
                if (arr[k, l] == -1)
                {
                    return -1;
                }
                else
                {
                    if (arr[k, l] == 0) count_0++;
                    else if (arr[k, l] == 1) count_1++;
                }
            }
        }

        int returnValue = count_0 == boxIndex * boxIndex ? 0 : count_1 == boxIndex * boxIndex ? 1 : -1;

        if (returnValue != -1) CheckZipVal(startIndex_Y, startIndex_X, boxIndex, arr);

        return returnValue;
    }
    
    private void CheckZipVal(int startIndex_Y, int startIndex_X, int boxIndex, int[,] arr)
    {
        for (int k = startIndex_Y; k < startIndex_Y + boxIndex; k++)//Y
        {
            for (int l = startIndex_X; l < startIndex_X + boxIndex; l++)//X
            {
                arr[k, l] = -1;
            }
        }
    }
}