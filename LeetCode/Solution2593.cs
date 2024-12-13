using System.Collections;
using System.Diagnostics;

namespace LeetCode
{
    /// <summary>
    /// 2593. Find Score of an Array After Marking All Elements
    /// https://leetcode.com/problems/find-score-of-an-array-after-marking-all-elements/
    /// </summary>
    public class Solution2593
    {
        // Решение из подсказика
        public long findScore(int[] nums)
        {
            long ans = 0;
            int[][] sorted = new int[nums.Length][];
            bool[] marked = new bool[nums.Length];

            for (int i = 0; i < nums.Length; i++)
            {
                sorted[i] = new int[2];
                sorted[i][0] = nums[i];
                sorted[i][1] = i;
            }

            var sorted2 = sorted.OrderBy(x => x[0]).ToArray();
            //Arrays.sort(sorted, (arr1, arr2)->arr1[0] - arr2[0]);

            for (int i = 0; i < nums.Length; i++)
            {
                int number = sorted2[i][0];
                int index = sorted2[i][1];
                if (!marked[index])
                {
                    ans += number;
                    marked[index] = true;
                    // mark adjacent elements if they exist
                    if (index - 1 >= 0)
                    {
                        marked[index - 1] = true;
                    }
                    if (index + 1 < nums.Length)
                    {
                        marked[index + 1] = true;
                    }
                }
            }

            return ans;
        }

        /// <summary>
        /// Моё обоссаное О квадрат решение.
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public long FindScore(int[] nums)
        {
            var sw = new Stopwatch();
            sw.Start();
            findScore(nums);
            sw.Stop();
            Console.WriteLine("norm solution: " + sw.ElapsedMilliseconds + " ms");
            sw.Restart();
            sw.Start();
            long score = 0;
            int? minIndex = null;
            int? min = null;
            var i2 = 0; ;
            while (true)
            {
                i2++;
                for (var i = 0; i < nums.Length; i++)
                {
                    if (nums[i] > -1)
                    {
                        if (min == null || nums[i] < min)
                        {
                            min = nums[i];
                            minIndex = i;
                        }
                    }
                }
                if (min == null)
                {
                    break;
                }
                //Console.WriteLine(i2 + " " + minIndex);
                score += min.Value;

                if (minIndex > 0)
                {
                    nums[minIndex.Value - 1] = -1;
                }
                nums[minIndex.Value] = -1;
                if (minIndex < nums.Length - 1)
                {
                    nums[minIndex.Value + 1] = -1;
                }

                min = null;
                minIndex = null;
            }

            sw.Stop();
            Console.WriteLine("bobina solution: " + sw.ElapsedMilliseconds + " ms");
            return score;
        }
    }
}
