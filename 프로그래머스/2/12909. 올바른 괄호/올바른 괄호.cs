using System.Collections.Generic;
using System.Linq;

public class Solution 
{
    public bool solution(string s) 
    {
        int count = 0;
        
        foreach (char item in s)
        {
            if (item == '(') count++;
            else count--;

            if(count < 0) return false;
        }

        return count == 0;
    }
}