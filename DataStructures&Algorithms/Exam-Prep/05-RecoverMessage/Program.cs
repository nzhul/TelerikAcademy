namespace RecoverMessage
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static SortedDictionary<char, Node> graph = new SortedDictionary<char, Node>();
        static void Main()
        {
            
            int n = int.Parse(Console.ReadLine());
            var noIncommingEdges = new SortedSet<char>();

            for (int i = 0; i < n; i++)
            {
                string currentMessage = Console.ReadLine();
                Node previousNode = GetNodeByCharFromGraph(currentMessage[0]);
                for (int j = 1; j < currentMessage.Length; j++)
                {
                    Node currentNode = GetNodeByCharFromGraph(currentMessage[j]);

                    previousNode.Successors.Add(currentNode);
                    currentNode.Parents.Add(previousNode);

                    previousNode = currentNode;
                }
            }

            foreach (var node in graph.Values)
            {
                if (node.Parents.Count == 0)
                {
                    noIncommingEdges.Add(node.Value);
                }
            }

            var result = new List<char>();

            while (noIncommingEdges.Count > 0)
            {
                var currentNodeSymbol = noIncommingEdges.Min;
                noIncommingEdges.Remove(currentNodeSymbol);

                result.Add(currentNodeSymbol);

                var currentNode = graph[currentNodeSymbol];
                var children = currentNode.Successors.ToList();
                foreach (var child in children)
                {
                    child.Parents.Remove(currentNode);
                    currentNode.Successors.Remove(child);

                    if (child.Parents.Count == 0)
                    {
                        noIncommingEdges.Add(child.Value);
                    }
                }
            }

            Console.WriteLine(String.Join("", result));


        }

        static Node GetNodeByCharFromGraph(char symbol)
        {
            if (graph.ContainsKey(symbol))
            {
                return graph[symbol];
            }

            var newNode = new Node
            {
                Value = symbol,
            };
            graph.Add(symbol, newNode);
            return newNode;
        }

        class Node
        {
            public Node()
            {
                this.Successors = new HashSet<Node>();
                this.Parents = new HashSet<Node>();
            }
            public char Value { get; set; }
            public ICollection<Node> Successors { get; set; }
            public ICollection<Node> Parents { get; set; }

            public override int GetHashCode()
            {
                return this.Value;
            }
        }
    }
}
