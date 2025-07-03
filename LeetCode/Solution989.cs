namespace LeetCode
{
    /// <summary>
    /// 989. Add to Array-Form of Integer
    /// https://leetcode.com/problems/add-to-array-form-of-integer/description/
    /// </summary>
    public class Solution989
    {
        public IList<int> AddToArrayForm(int[] num, int k)
        {
            var list = num.ToList();
            var index = num.Length - 1;

            //[2.7.4]
            //181
            int nextvalue = 0;
            while (true)
            {
                var ostattok = k % 10;
                k = k / 10;
                if(index == -1)
                {
                    list.Insert(0, 0);
                    index = 0;
                }
                var value = list[index] + ostattok + nextvalue;
                if(value > 9)
                {
                    value = value - 10;
                    nextvalue = 1;
                }
                else
                {
                    nextvalue = 0;
                }
                list[index] = value;
                if(k > 0 || nextvalue > 0)
                {
                    index--;
                }
                else
                {
                    break;
                }
            }
            return list;
        }
    }
}
