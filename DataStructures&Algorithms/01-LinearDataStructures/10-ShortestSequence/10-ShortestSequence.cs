namespace ShortestSequence
{
    using System.Collections.Generic;
    using System.Text;
    public class ShortestSequence
    {
        static int N = 5;
        static int M = 16;
        public static void Main()
        {
            var start = new Node<int>();
            start.Value = N;

            var queue = new Queue<Node<int>>();
            queue.Enqueue(start);

            while (queue.Count > 0)
            {
                var currentNode = queue.Dequeue();
                CreateNewNode(currentNode, OperationOne(currentNode.Value), queue);

                if (queue.Count > 0)
                {
                    CreateNewNode(currentNode, OperationTwo(currentNode.Value), queue);
                }

                if (queue.Count > 0)
                {
                    CreateNewNode(currentNode, OperationMultiply(currentNode.Value), queue);
                }
            }
        }

        private static void CreateNewNode(Node<int> currentNode, int newValue, Queue<Node<int>> queue)
        {
            var nodeOne = new Node<int>();
            nodeOne.Value = newValue;
            nodeOne.Previous = currentNode;

            if (nodeOne.Value == M)
            {
                Print(nodeOne);
                queue.Clear();
            }
            else if(nodeOne.Value < M)
            {
                queue.Enqueue(nodeOne);
            }
        }

        private static void Print(Node<int> nodeOne)
        {
            var result = new Stack<int>();
            var currentNode = nodeOne;
            while (currentNode.Previous != null)
            {
                result.Push(currentNode.Value);
                currentNode = currentNode.Previous;
            }
            result.Push(currentNode.Value);

            var sb = new StringBuilder();
            while (result.Count > 0)
            {
                if (sb.Length == 0)
                {
                    sb.Append(result.Pop());
                }
                else
                {
                    sb.Append(" - >" + result.Pop());
                }
            }
            System.Console.WriteLine(sb.ToString());
        }

        private static int OperationOne(int number)
        {
            return number += 1;
        }

        private static int OperationTwo(int number)
        {
            return number += 2;
        }

        private static int OperationMultiply(int number)
        {
            return number *= 2;
        }
    }
}