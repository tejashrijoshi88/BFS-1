// time complexity- O(V+E) v= number of courses, E = number of prerequisites
// space complexity - O(V+E) v= number of courses, E = number of prerequisites
// Approach - Create an Adjecency list to store prerequisits and degrees array for independent courses
// maintain a queue to process nodes with no Pre-requisite
public class Solution
{
    public bool CanFinish(int numCourses, int[][] prerequisites)
    {
        // get an array of independent courses
        // get adjecency list 
        int[] degrees = new int[numCourses];
        Dictionary<int, List<int>> dict = new Dictionary<int, List<int>>();
        Queue<int> bfs = new Queue<int>();

        for (int i = 0; i < prerequisites.Length; i++)
        {
            degrees[prerequisites[i][1]]++;
            if (!dict.ContainsKey(prerequisites[i][0]))
            {
                dict.Add(prerequisites[i][0], new List<int>());
                dict[prerequisites[i][0]].Add(prerequisites[i][1]);
            }
            else
            {
                dict[prerequisites[i][0]].Add(prerequisites[i][1]);
            }
        }
        for (int i = 0; i < degrees.Length; i++)
        {
            if (degrees[i] == 0)
            {
                bfs.Enqueue(i);
            }
        }
        while (bfs.Count() > 0)
        {
            int course = bfs.Dequeue();
            if (dict.ContainsKey(course))
            {
                List<int> dependentCourses = dict[course];

                for (int i = 0; i < dependentCourses.Count(); i++)
                {
                    degrees[dependentCourses[i]]--;
                    if (degrees[dependentCourses[i]] == 0)
                    {
                        bfs.Enqueue(dependentCourses[i]);
                    }
                }
            }
        }
        for (int i = 0; i < degrees.Length; i++)
        {
            if (degrees[i] != 0) return false;
        }
        return true;
    }
}