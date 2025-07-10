
namespace LeetCode
{
    /// <summary>
    /// 200. Number of Islands
    /// https://leetcode.com/problems/number-of-islands/description/
    /// </summary>
    public class Solution200
    {
        public int NumIslands(char[][] grid)
        {
            var check = new bool[grid.Length, grid[0].Length];
            var count = 0;
            var stack = new Stack<Tuple<int, int>>();
            for (var i = 0; i < check.GetLength(0); i++)
            {
                for (var j = 0; j < check.GetLength(1); j++)
                {
                    if (check[i, j])
                    {
                        continue;
                    }

                    if (grid[i][j] == '1')
                    {
                        count++;

                        var i1 = i;
                        var j1 = j;
                        while (true)
                        {
                            //up
                            var i1next = i1 - 1;
                            var j1next = j1;
                            var result = Move();
                            if (result)
                            {
                                continue;
                            }

                            //right

                            i1next = i1;
                            j1next = j1 + 1;
                            result = Move();
                            if (result)
                            {
                                continue;
                            }

                            //left

                            i1next = i1;
                            j1next = j1 - 1;
                            result = Move();
                            if (result)
                            {
                                continue;
                            }


                            //down
                            i1next = i1 + 1;
                            j1next = j1;
                            result = Move();
                            if (result)
                            {
                                continue;
                            }

                            if (stack.Count > 0)
                            {
                                var prevPosition = stack.Pop();
                                i1 = prevPosition.Item1;
                                j1 = prevPosition.Item2;
                            }
                            else
                            {
                                break;
                            }

                            bool Move()
                            {
                                if (i1next < 0 || i1next >= check.GetLength(0))
                                {
                                    return false;
                                }
                                if (j1next < 0 || j1next >= check.GetLength(1))
                                {
                                    return false;
                                }
                                if (check[i1next, j1next] == false)
                                {
                                    check[i1next, j1next] = true;
                                    if (grid[i1next][j1next] == '1')
                                    {
                                        stack.Push(new Tuple<int, int>(i1, j1));
                                        i1 = i1next;
                                        j1 = j1next;
                                        return true;
                                    }
                                }
                                return false;
                            }
                        }
                    }
                }
            }


            return count;
        }
    }
}
