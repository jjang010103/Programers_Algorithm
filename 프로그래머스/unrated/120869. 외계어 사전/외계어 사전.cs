using System;
using System.Linq;

public class Solution {
    public int solution(string[] spell, string[] dic) 
    {
        int answer = dic.Any(i => spell.All(j => i.Contains(j))) ? 1 : 2;
        
        return answer;
    }
}