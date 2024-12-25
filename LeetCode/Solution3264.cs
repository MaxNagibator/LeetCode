namespace LeetCode
{
    /// <summary>
    /// 3264. Final Array State After K Multiplication Operations I
    /// https://leetcode.com/problems/final-array-state-after-k-multiplication-operations-i
    /// </summary>
    public class Solution3264
    {

        public int[] GetFinalState(int[] nums, int k, int multiplier)
        {
            List<Value> values = new List<Value>(nums.Length);

            for (var i = 0; i < nums.Length; i++)
            {
                values.Add(new Value { index = i, value = nums[i] });
            }

            values = values.OrderBy(x => x.value).ToList();

            for (var i = 0; i < k; i++)
            {
                values[0].value *= multiplier;
                int? insertIndex = null;
                for (var j = 1; j < values.Count; j++)
                {
                    if (values[j].value < values[0].value
                        || (values[j].value == values[0].value && values[j].index < values[0].index))
                    {
                        insertIndex = j;
                    }
                    else
                    {
                        break;
                    }
                }
                if (insertIndex != null)
                {
                    values.Insert(insertIndex.Value + 1, values[0]);
                    values.RemoveAt(0);
                }
            }
            return values.OrderBy(x=>x.index).Select(x=>x.value).ToArray();
        }

        public class Value
        {
            public int value;
            public int index;
        }
    }
}
