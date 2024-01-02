using System;
using System.Linq;

public class Solution 
{
    public int solution(string skill, string[] skill_trees) 
    {
        for (int i = 1; i < skill.Length; i++)
        {
            for (int j = 0; j < skill_trees.Length; j++)
            {
                if (skill_trees[j] == null) continue;

                int befSkillIndex = skill_trees[j].IndexOf(skill[i - 1]);
                int currSkillIndex = skill_trees[j].IndexOf(skill[i]);

                if(currSkillIndex != -1 
                   && (befSkillIndex == -1 || currSkillIndex < befSkillIndex))
                {
                    skill_trees[j] = null;
                }
            }
        }

        return skill_trees.Count(i => i != null);
    }
}