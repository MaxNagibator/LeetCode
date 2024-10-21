using System.Collections;

namespace LeetCode
{
    /// <summary>
    /// 1593. Split a String Into the Max Number of Unique Substrings
    /// https://leetcode.com/problems/split-a-string-into-the-max-number-of-unique-substrings/description/
    /// </summary>
    internal class Solution1593
    {
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
    }
}
