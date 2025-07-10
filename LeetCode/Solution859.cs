namespace LeetCode
{
    /// <summary>
    /// 859. Buddy Strings
    /// https://leetcode.com/problems/buddy-strings/description/
    /// </summary>
    public class Solution859
    {
        public bool BuddyStrings(string s, string goal)
        {
            if (s.Length != goal.Length)
            {
                return false;
            }

            byte notEqualsCount = 0;
            int? char1Index = null;
            int? char2Index = null;
            for (var i = 0; i < goal.Length; i++)
            {
                if (goal[i] != s[i])
                {
                    if (char1Index != null)
                    {
                        char2Index = i;
                    }
                    else
                    {
                        char1Index = i;
                    }
                    notEqualsCount++;
                    if (notEqualsCount > 2)
                    {
                        return false;
                    }
                }
            }

            if (notEqualsCount == 0)
            {
                // aba    aba  -> aab
                var sortArray = s.ToCharArray().OrderBy(x => x).ToArray();
                for (var i = 0; i < sortArray.Length - 1; i++)
                {
                    if (sortArray[i] == sortArray[i + 1])
                    {
                        return true;
                    }
                }
                // строки полностью совпадают
                return false;
            }

            if (notEqualsCount == 1)
            {
                return false;
            }

            // ab   ba    0  1
            if (goal[char1Index!.Value] == s[char2Index!.Value] &&
                goal[char2Index.Value] == s[char1Index.Value])
            {
                return true;
            }
            return false;
        }
    }
}
