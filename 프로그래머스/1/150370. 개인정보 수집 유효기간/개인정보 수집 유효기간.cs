using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    public int[] solution(string today, string[] terms, string[] privacies) 
    {
            List<int> answer = new List<int>();

            for (int i = 0; i < privacies.Length; i++)
            {
                string date = GetSplitData(privacies[i], 0);

                string termName = GetSplitData(privacies[i], 1);

                int termMonth = Convert.ToInt16(GetSplitData(terms.First(j => j.Contains(termName)), 1));

                if (termMonth * 28 <= GetDate(today) - GetDate(date))
                {
                    answer.Add(i + 1);
                }
            }

            return answer.ToArray();
    }

    private string GetSplitData(string item, int index) 
    {
        return item.Split(' ')[index];
    }

    private int GetDate(string date)
    {
        int[] splitedDate = date.Split('.').Select(i => Convert.ToInt32(i)).ToArray();

        return (splitedDate[0] * (12 * 28)) + (splitedDate[1] * 28) + splitedDate[2];
    }
}