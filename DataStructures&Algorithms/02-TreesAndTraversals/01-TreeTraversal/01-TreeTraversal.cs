using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeTraversal
{
    class Program
    {
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

        static void Main(string[] args)
        {
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

        //3. Find all middle nodes


    }
}
