using System;

public class Solution 
{
    public int[] solution(int brown, int yellow) 
    {
        int yellowWidth = yellow;
        int yellowHeight = 1;

        while (GetBrownCountNeedForYellow(yellowWidth, yellowHeight) != brown)
        {
            do
            {
                yellowHeight++;
                yellowWidth = yellow / yellowHeight;
            }
            while (yellow % yellowHeight != 0);
        }

        return new int[] { yellowWidth + 2, yellowHeight + 2 };
    }
    
    public int GetBrownCountNeedForYellow(int yellowWidth, int yellowHeight)
    {
        int value = (yellowWidth * 2) + (yellowHeight * 2) + 4;

        return value;
    }
}