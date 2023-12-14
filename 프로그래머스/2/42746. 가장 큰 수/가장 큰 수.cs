using System;
using System.Linq;

public class Solution 
{
    public string solution(int[] numbers) 
    {
        if (numbers.All(i => i == 0)) return "0";

        Array.Sort(numbers, (n1, n2) => 
        {
            string s1 = n1.ToString();
            string s2 = n2.ToString();

            int sum1 = Convert.ToInt32(s1 + s2);
            int sum2 = Convert.ToInt32(s2 + s1);

            return sum2 - sum1; 
        });

        return string.Join("", numbers);
    }
}