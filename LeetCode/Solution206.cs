namespace LeetCode
{
    /// <summary>
    /// 206. Reverse Linked List
    /// https://leetcode.com/problems/reverse-linked-list/
    /// </summary>
    public class Solution206
    {
        // хуйня от максима
        public ListNode ReverseList(ListNode head)
        {
            var current = head;
            ListNode? prev = null;
            while (current != null)
            {
                var currentNext = current.next;
                current.next = prev;
                prev = current;

                if(currentNext == null)
                {
                    return current;
                }
                current = currentNext;
            }
            return current;
        }

        public class ListNode
        {
            public int val;
            public ListNode? next;
            public ListNode(int val = 0, ListNode? next = null)
            {
                this.val = val;
                this.next = next;
            }
        }
    }
}
