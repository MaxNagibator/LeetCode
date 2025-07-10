namespace LeetCode
{
    /// <summary>
    /// 645. Set Mismatch
    /// https://leetcode.com/problems/set-mismatch/description/
    /// </summary>
    public class Solution645
    {
        public int[] FindErrorNums(int[] nums)
        {
            nums = nums.OrderBy(x => x).ToArray();
            var lost = -1;
            var duplicate = -1;
            for (var i = 0; i < nums.Length; i++)
            {
                var ind = i + (duplicate > 0 ? 1 : 0);
                if(ind >= nums.Length)
                {
                    return [duplicate, nums.Length];
                }
                if (lost < 1 && nums[ind] != i + 1)
                {
                    lost = i + 1;
                }
                if (duplicate < 0 && i < nums.Length - 1 && nums[i] == nums[i + 1])
                {
                    duplicate = nums[i];
                }
                if (lost > 0 && duplicate > 0)
                {
                    return [duplicate, lost];
                }
            }
            throw new Exception();
        }
    }
}
