using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeTraversal
{
    class Program
    {
        static void Main(string[] args)
        {

            // Test Input (hint: use Alt + LeftMouseClick to select multiple rows at once)
            //
            //7
            //2 4
            //3 2
            //5 0
            //3 5
            //5 6
            //5 1

            var N = int.Parse(Console.ReadLine());
            var nodes = new Node<int>[N];

            for (int i = 0; i < N; i++)
            {
                nodes[i] = new Node<int>(i);
            }

            for (int i = 1; i <= N - 1; i++)
            {
                string edgeAsString = Console.ReadLine();
                var edgeParts = edgeAsString.Split(' ');

                int parentId = int.Parse(edgeParts[0]);
                int childId = int.Parse(edgeParts[1]);

                nodes[parentId].Children.Add(nodes[childId]);
                nodes[childId].HasParent = true;
            }

            // 1. Find the root
            var root = FindRoot(nodes);
            Console.WriteLine("The root of the tree is: {0}", root.Value);

            //2. Find all leafs
            var leafs = FindAllLeafs(nodes);
            Console.WriteLine("Leafs: ");
            foreach (var leaf in leafs)
            {
                Console.Write("{0}, ", leaf.Value);
            }
            Console.WriteLine();

            //3. Find all middle nodes
            // For one node to be middle-node it must not be root and must have childrens
            var middleNodes = FindAllMiddleNodes(nodes);
            Console.WriteLine("Middle nodes: ");
            foreach (var node in middleNodes)
            {
                Console.Write("{0}, ", node.Value);
            }
            Console.WriteLine();

            //4. Find the longest path
            var longestPath = FindLongestPath(FindRoot(nodes));
            Console.WriteLine("Longest path from the root is: {0}", longestPath);

            //5. * all paths in the tree with given sum S of their nodes
            int searchedSum = 8;
            HashSet<string> allPaths = FindAllPathsWithSum(nodes, searchedSum);
            Console.WriteLine("Path/s with sum of {0} is/are: {1}", searchedSum, String.Join(" and ", allPaths));

            //6 * all subtrees with given sum S of their nodes
            //TODO: Finish me!

        }

        private static void BFS(Node<int> node, Func<Node<int>, bool> action)
        {
            Queue<Node<int>> queue = new Queue<Node<int>>();
            queue.Enqueue(node);

            while (queue.Count > 0)
            {
                var n = queue.Dequeue();
                if (action != null)
                {
                    if (!action(n))
                    {
                        queue.Clear();
                        continue;
                    }
                }

                foreach (var child in n.Children)
                {
                    queue.Enqueue(child);
                }
            }
        }

        public static void DFS(Node<int> node, Func<Node<int>, bool> action)
        {
            Stack<Node<int>> stack = new Stack<Node<int>>();
            stack.Push(node);

            while (stack.Count > 0)
            {
                var n = stack.Pop();
                if (action != null)
                {
                    if (!action(n))
                    {
                        continue;
                    }
                }

                foreach (var child in n.Children)
                {
                    stack.Push(child);
                }
            }
        }

        private static HashSet<string> FindAllPathsWithSum(Node<int>[] nodes, int searchedSum)
        {
            HashSet<string> treePaths = new HashSet<string>();

            foreach (var node in nodes)
            {
                if (node.Children.Count > 0)
                {
                    var stack = new Stack<int>();

                    var safeNode = node;
                    var sum = 0;
                    DFS(node, n => {
                        if (n.Parent == safeNode)
                        {
                            sum = safeNode.Value;
                            if (stack.Count > 1)
                            {
                                stack.Pop();
                            }
                        }

                        stack.Push(n.Value);
                        sum += n.Value;

                        if (sum == searchedSum)
                        {
                            treePaths.Add(String.Join(" -> ", stack.Reverse()));
                        }

                        if (sum > searchedSum)
                        {
                            stack.Pop();
                            sum -= n.Value;
                            return false;
                        }
                        return true;
                    });
                }
            }

            return treePaths;
        }

        private static List<Node<int>> FindAllLeafs(Node<int>[] nodes)
        {
            List<Node<int>> leafs = new List<Node<int>>();

            foreach (var node in nodes)
            {
                if (node.Children.Count == 0)
                {
                    leafs.Add(node);
                }
            }

            return leafs;
        }

        private static List<Node<int>> FindAllMiddleNodes(Node<int>[] nodes)
        {
            List<Node<int>> middleNodes = new List<Node<int>>();

            foreach (var node in nodes)
            {
                if (node.HasParent && node.Children.Count > 0)
                {
                    middleNodes.Add(node);
                }
            }

            return middleNodes;
        }

        private static int FindLongestPath(Node<int> root)
        {
            if (root.Children.Count == 0)
            {
                return 0;
            }

            int maxPath = 0;
            foreach (var node in root.Children)
            {
                maxPath = Math.Max(maxPath, FindLongestPath(node));
            }

            return maxPath + 1;
        }

        static Node<int> FindRoot(Node<int>[] nodes)
        {
            var hasParent = new bool[nodes.Length];

            foreach (var node in nodes)
            {
                foreach (var child in node.Children)
                {
                    hasParent[child.Value] = true;
                }
            }

            for (int i = 0; i < hasParent.Length; i++)
            {
                if (!hasParent[i])
                {
                    return nodes[i];
                }
            }

            throw new ArgumentException("nodes", "The tree has no root.");
        }


    }
}
