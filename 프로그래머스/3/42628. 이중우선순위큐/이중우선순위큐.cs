using System;
using System.Linq;
using System.Collections.Generic;

public class Solution 
{
    public int[] solution(string[] operations) 
    {
        List<int> list = new List<int>();

        for (int i = 0; i < operations.Length; i++)
        {
            string[] temp = operations[i].Split(' ');
            
            if(temp[0] == "I") list.Add(Convert.ToInt32(temp[1]));
            else if(temp[0] == "D" && list.Count != 0)
            {
                int tempVal = temp[1] == "1" ? list.Max() : list.Min();
                
                list.Remove(tempVal);
            }
        }

        if(list.Count == 0) return new int[] { 0, 0 };
        else return new int[] { list.Max(), list.Min() };
    }
}