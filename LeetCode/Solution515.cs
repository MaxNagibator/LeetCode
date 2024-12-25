namespace LeetCode
{
    /// <summary>
    /// 515. Find Largest Value in Each Tree Row
    /// https://leetcode.com/problems/find-largest-value-in-each-tree-row/description/
    /// </summary>
    public class Solution515
    {
        // хуйня от максима
        public IList<int> LargestValues(TreeNode root)
        {
            if (root == null)
            {
                return new List<int>();
            }
            var dictionary = new Dictionary<int, int>();
            GoTree(dictionary, root, 0);
            return dictionary.Values.ToList();
        }

        private void GoTree(Dictionary<int, int> dict, TreeNode node, int level)
        {
            if (!dict.ContainsKey(level))
            {
                dict[level] = node.val;
            }
            else
            {
                if (dict[level] < node.val)
                {
                    dict[level] = node.val;
                }
            }
            if (node.left != null)
            {
                GoTree(dict, node.left, level + 1);
            }
            if (node.right != null)
            {
                GoTree(dict, node.right, level + 1);
            }
        }

        internal TreeNode? GetTestData(int?[] value, int index = 0)
        {
            if (index >= value.Length)
            {
                return null;
            }
            if (value[index] == null)
            {
                return null;
            }

            var node = new TreeNode();
            node.val = value[index]!.Value;
            node.left = GetTestData(value, index * 2 + 1);
            node.right = GetTestData(value, index * 2 + 2);
            return node;
        }

        public class TreeNode
        {
            public int val;
            public TreeNode? left;
            public TreeNode? right;
            public TreeNode(int val = 0, TreeNode? left = null, TreeNode? right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }
    }
}
