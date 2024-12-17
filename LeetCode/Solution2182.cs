using System;
using System.Collections;
using System.Diagnostics;
using System.Text;

namespace LeetCode
{
    /// <summary>
    /// 2182. Construct String With Repeat Limit
    /// https://leetcode.com/problems/construct-string-with-repeat-limit/
    /// </summary>
    public class Solution2182
    {
        public class MyChar
        {
            private int count;

            public char Value { get; set; }
            public int Count
            {
                get => count;
                set
                {
                    if (count == -1)
                    {
                        var a = 1;
                    }
                    count = value;
                }
            }
        }
        public string RepeatLimitedString(string s, int repeatLimit)
        {
            var array3 = s.GroupBy(x => x)
                .Select(x => new MyChar { Value = x.Key, Count = x.Count() })
                .OrderByDescending(x => x.Value).ToArray();
            var sb = new StringBuilder();
            var currentLimit = 1;
            var currentIndex = 0;
            var current = array3[0].Value;
            array3[0].Count--;
            sb.Append(current);
            while (true)
            {
                if (currentIndex > array3.Length - 1)
                {
                    break;
                }
                if (array3[currentIndex].Count <= 0)
                {
                    currentIndex++;
                    continue;
                }
                if (array3[currentIndex].Value == current)
                {
                    currentLimit++;
                }
                else
                {
                    currentLimit = 1;
                }
                if (currentLimit > repeatLimit)
                {
                    var found = false;
                    for (var i2 = currentIndex + 1; i2 < array3.Length; i2++)
                    {
                        if (array3[i2].Count == 0)
                        {
                            continue;
                        }
                        sb.Append(array3[i2].Value);
                        array3[i2].Count--;
                        current = array3[i2].Value;
                        currentLimit = 1;
                        found = true;
                        break;
                    }
                    if (found == false)
                    {
                        break;
                    }
                }

                current = array3[currentIndex].Value;
                sb.Append(array3[currentIndex].Value);
                array3[currentIndex].Count--;

            }
            return sb.ToString();
        }
    }
}
