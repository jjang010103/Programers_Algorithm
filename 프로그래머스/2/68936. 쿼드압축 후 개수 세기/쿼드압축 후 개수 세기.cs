using System;

public class Solution 
{
    private int Count_0 { get; set; }
    private int Count_1 { get; set; }
    
    public int[] solution(int[,] arr) 
    {
        Count_0 = 0;
        Count_1 = 0;

        int arrLength = arr.GetLength(0);

        for (int boxIndex = arrLength; boxIndex > 0; boxIndex /= 2)//자를 갯수
        {
            for (int startIndex_Y = 0 * boxIndex; startIndex_Y < arrLength; startIndex_Y += boxIndex)
            {
                for (int startIndex_X = 0 * boxIndex; startIndex_X < arrLength; startIndex_X += boxIndex)
                {
                    GetWhichNumberZip(startIndex_Y, startIndex_X, boxIndex, arr);
                }
            }
        }

        return new int[] { Count_0, Count_1 };
    }
    
    private void GetWhichNumberZip(int startIndex_Y, int startIndex_X, int boxIndex, int[,] arr)
    {
        int tempCount_0 = 0;
        int tempCount_1 = 0;

        for (int k = startIndex_Y; k < startIndex_Y + boxIndex; k++)//Y
        {
            for (int l = startIndex_X; l < startIndex_X + boxIndex; l++)//X
            {
                if (arr[k, l] == -1)
                {
                    return;
                }
                else
                {
                    if (arr[k, l] == 0) tempCount_0++;
                    else if (arr[k, l] == 1) tempCount_1++;
                }
            }
        }

        bool isCheck = false;

        if (isCheck |= tempCount_0 == 0) Count_1++;
        else if (isCheck |= tempCount_1 == 0) Count_0++;

        if(isCheck) CheckIsZipVal(startIndex_Y, startIndex_X, boxIndex, arr);
    }

    private void CheckIsZipVal(int startIndex_Y, int startIndex_X, int boxIndex, int[,] arr)
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