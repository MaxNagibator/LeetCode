
namespace LeetCode
{
    /// <summary>
    /// 3264. Final Array State After K Multiplication Operations I
    /// https://leetcode.com/problems/final-array-state-after-k-multiplication-operations-i
    /// </summary>
    public class Solution1
    {
        public int[] TwoSum(int[] nums, int target) 
        {
            for(var j = 0; j < nums.Length; j++)
            {
                for(var i = j + 1; i < nums.Length; i++)
                {
                    if(nums[i] + nums[j] == target)
                    {
                        return new int[]{i,j};
                    }
                }
            }
            throw new Exception("not found");
        }
    }
}
