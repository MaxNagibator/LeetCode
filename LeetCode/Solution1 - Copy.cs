
namespace LeetCode
{
    /// <summary>
    /// 3075. Maximize Happiness of Selected Children
    /// https://leetcode.com/problems/maximize-happiness-of-selected-children/description/?envType=daily-question&envId=2025-12-25
    /// </summary>
    public class Solution3075
    {
        public long MaximumHappinessSum(int[] happiness, int k)
        {
            // 5 8 7 1  / 2
            // 8 7 5 1
            // 8 - 0
            // 7 - 1
            // 5 - 2
            // 1 - 3

            var sorted = happiness.OrderByDescending(x => x).ToArray();
            long sum = 0;
            for (var i = 0; i < k; i++)
            {
                var put = sorted[i] - i;
                if (put < 0)
                {
                    break;
                }
                sum += put;
            }
            return sum;
        }
    }
}
