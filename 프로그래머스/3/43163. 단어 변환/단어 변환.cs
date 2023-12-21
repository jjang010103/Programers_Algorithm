using System.Collections.Generic;
using System.Linq;

public class Solution {

    private string[] Words { get; set; }

    public int solution(string begin, string target, string[] words) 
    {
        if (!words.Contains(target)) return 0;

        this.Words = words;

        int answer = 0;

        IEnumerable<string> tempValArr = new string[] { begin };

        while (!tempValArr.Contains(target))
        {
            tempValArr = ChangeWord(tempValArr);
            answer++;
        }

        return answer;
    }

    private IEnumerable<string> ChangeWord(IEnumerable<string> beginArr)
    {
        foreach (string begin in beginArr)
        {
            foreach (string word in this.Words)
            {
                int count = 0;
                
                for(int i = 0; i < begin.Length; i++)
                {
                    if (begin[i] != word[i]) count++;
                }

                if (count == 1) yield return word;
            }
        }
    }
}