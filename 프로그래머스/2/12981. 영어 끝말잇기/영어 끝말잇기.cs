using System;
using System.Linq;
using System.Collections.Generic;

class Solution
{
    public int[] solution(int n, string[] words)
    {
        List<string> usedWordList = new List<string>() { words[0] };

        for (int i = 1; i < words.Length; i++)
        {
            string beforeWord = words[i - 1];
            string currentWord = words[i];

            if (beforeWord.Last() != currentWord.First() || usedWordList.Contains(currentWord))
            {
                return new int[] { i % n + 1, i / n + 1 };
            }
            else
            {
                usedWordList.Add(currentWord);
            }
        }

        return new int[] { 0, 0 };
    }
}