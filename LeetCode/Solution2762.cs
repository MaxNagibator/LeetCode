using System;
using System.Collections;
using System.Diagnostics;

namespace LeetCode
{
    /// <summary>
    /// 2762. Continuous Subarrays
    /// https://leetcode.com/problems/continuous-subarrays
    /// </summary>
    public class Solution2762
    {
        public long ContinuousSubarrays(int[] nums)
        {
            int rear = 0;
            long ans = 0;
            SortedDictionary<int, int> st = new SortedDictionary<int, int>();

            for (int front = 0; front < nums.Length; front++)
            {
                if (!st.ContainsKey(nums[front]))
                    st[nums[front]] = 0;
                st[nums[front]]++;

                while (st.Count > 1 && st.Last().Key - st.First().Key > 2)
                {
                    st[nums[rear]]--;
                    if (st[nums[rear]] == 0)
                        st.Remove(nums[rear]);
                    rear++;
                }

                ans += front - rear + 1;
            }

            return ans;
        }

        /// <summary>
        /// Шляпа от стримера.
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public long ContinuousSubarraysBobina(int[] nums)
        {
            var sw = new Stopwatch();
            sw.Start();
            long sum = 0;
            sum += nums.Length;

            if (nums.Length == 1)
            {
                return 1;
            }
            var isUnique = true;
            for (var i = 1; i < nums.Length; i++)
            {
                if (Math.Abs(nums[i] - nums[0]) > 2)
                {
                    isUnique = false;
                    break;
                }
            }
            if (isUnique)
            {
                return (((long)nums.Length + 1) * nums.Length) / 2;
            }
            for (var i = 0; i < nums.Length; i++)
            {
                var subarray = 1;
                var min = nums[i];
                var max = nums[i];
                while (true)
                {
                    if (i + subarray < nums.Length)
                    {
                        var newElement = nums[i + subarray];
                        var isGoodElement = true;
                        var diff1 = min - newElement;
                        var diff2 = max - newElement;
                        if (diff1 < -2 || diff1 > 2)
                        {
                            isGoodElement = false;
                        }
                        if (diff2 < -2 || diff2 > 2)
                        {
                            isGoodElement = false;
                        }
                        if (isGoodElement)
                        {
                            if (newElement > max)
                            {
                                max = newElement;
                            }
                            if (newElement < min)
                            {
                                min = newElement;
                            }
                            subarray++;
                            sum++;
                            continue;
                        }
                    }
                    break;
                }
            }

            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds + " ms ");
            return sum;

        }
    }
}
