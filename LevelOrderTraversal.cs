// for BFS time complexity O(n) , In DFS - O(n)
// space complexity - O(n), O(h) for stack
// approach - In BFS, we go level by level. We add the node to queue and iterate while queue is not empty
// And maintain a size variable to distinguish between levels. Add the popped nodes to result list.
// In DFS, we check if the level is equal to size of result, we add a new level list to result.
// else add the node to level node.
/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution
{
    IList<IList<int>> res = new List<IList<int>>();
    public IList<IList<int>> LevelOrder(TreeNode root)
    {
        // BFS
        // Queue<TreeNode> BFS = new Queue<TreeNode>();
        // IList<IList<int>> res = new List<IList<int>>();
        // if(root ==null)
        // {
        //     return res;
        // }
        // BFS.Enqueue(root);
        // while(BFS.Count >0)
        // {
        //     List<int> level = new List<int>();
        //     int size = BFS.Count();
        //     for(int i=0; i<size; i++)
        //     {
        //         TreeNode node = BFS.Dequeue();
        //         level.Add(node.val);
        //         if(node.left !=null)
        //         {
        //             BFS.Enqueue(node.left);
        //         }
        //         if(node.right !=null)
        //         {
        //             BFS.Enqueue(node.right);
        //         }
        //     }
        //     res.Add(level);
        // }
        // return res;


        // DFS Approach
        dfs(root, 0);
        return res;

    }

    public void dfs(TreeNode root, int level)
    {
        // base
        if (root == null)
        {
            return;
        }
        // logic
        if (res.Count == level)
        {
            res.Add(new List<int> { root.val });
        }
        else
        {
            res[level].Add(root.val);
        }
        dfs(root.left, level + 1);
        dfs(root.right, level + 1);
    }
}