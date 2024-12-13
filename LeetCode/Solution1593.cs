using System.Collections;

namespace LeetCode
{
    /// <summary>
    /// 1593. Split a String Into the Max Number of Unique Substrings
    /// https://leetcode.com/problems/split-a-string-into-the-max-number-of-unique-substrings/description/
    /// </summary>
    internal class Solution1593
    {
        // трешанина от бобины
        public int MaxUniqueSplit(string s)
        {
            var maxNumber = 1;
            if (s.Length == 1)
            {
                return maxNumber;
            }

            var maxBorders = 2 << s.Length - 2;
            for (var i = maxBorders - 1; i > 0; i--)
            {
                BitArray b = new BitArray(new int[] { i });
                List<string> parts = new List<string>();

                var index = 0;
                var length = 1;
                for (var j = 0; j < s.Length; j++)
                {
                    if (b[j])
                    {
                        var part = s.Substring(index, length);
                        index += length;
                        length = 1;
                        parts.Add(part);
                    }
                    else
                    {
                        length++;
                    }
                }
                var part2 = s.Substring(index);
                parts.Add(part2);
                if (parts.GroupBy(x => x).Count() == parts.Count)
                {
                    if (parts.Count > maxNumber)
                    {
                        maxNumber = parts.Count;
                    }
                }
            }
            return maxNumber;
        }

        // решение от рокича
        public int MaxUniqueSplitRocka_0(string s)
        {
            return Backtrack(s, 0, new HashSet<string>());
        }

        private int Backtrack(string s, int start, HashSet<string> used)
        {
            if (start == s.Length) { return 0; }
            int maxSplits = 0;
            for (int end = start + 1; end <= s.Length; end++)
            {
                string substring = s.Substring(start, end - start);
                if (!used.Contains(substring))
                {
                    used.Add(substring);
                    maxSplits = Math.Max(maxSplits, 1 + Backtrack(s, end, used));
                    used.Remove(substring);
                }
            }
            return maxSplits;
        }
    }
}
