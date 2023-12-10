using System;
using System.Linq;

public class Solution 
{
    public bool solution(int x) 
    {
        var sum = x.ToString().Select(i => Convert.ToInt32(i.ToString())).Sum();

        bool answer = x % sum == 0;

        return answer;
    }
}