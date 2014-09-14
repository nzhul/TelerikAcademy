namespace CableCompany
{
    /* 
     *  You are given a cable TV company. The company needs to lay cable to a new 
     *  neighborhood (for every house). If it is constrained to bury the cable only 
     *  along certain paths, then there would be a graph representing which points are
     *  connected by those paths. But the cost of some of the paths is more expensive 
     *  because they are longer. If every house is a node and every path 
     *  from house to house is an edge, find a way to minimize the cost for cables. 
     */

    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            SortedSet<HouseConnection> priority = new SortedSet<HouseConnection>();
            int numberOfNodes = 14;
            bool[] usedHouses = new bool[numberOfNodes + 1];
            List<HouseConnection> mpdNodes = new List<HouseConnection>();
            List<HouseConnection> edges = new List<HouseConnection>();

            edges.Add(new HouseConnection(1, 3, 5));
            edges.Add(new HouseConnection(1, 2, 4));
            edges.Add(new HouseConnection(1, 4, 9));
            edges.Add(new HouseConnection(2, 4, 2));
            edges.Add(new HouseConnection(3, 4, 20));
            edges.Add(new HouseConnection(3, 5, 7));
            edges.Add(new HouseConnection(4, 5, 8));
            edges.Add(new HouseConnection(5, 6, 12));
            edges.Add(new HouseConnection(5, 10, 2));
            edges.Add(new HouseConnection(5, 9, 12));
            edges.Add(new HouseConnection(5, 8, 33));
            edges.Add(new HouseConnection(5, 1, 1));
            edges.Add(new HouseConnection(5, 7, 13));
            edges.Add(new HouseConnection(5, 14, 111));

            // adding edges that connect the node 1 with all the others - 2, 3, 4
            for (int i = 0; i < edges.Count; i++)
            {
                if (edges[i].StartHouse == edges[0].StartHouse)
                {
                    priority.Add(edges[i]);
                }
            }

            usedHouses[edges[0].StartHouse] = true;

            FindMinimumSpanningTree(usedHouses, priority, mpdNodes, edges);

            PrintMinimumSpanningTree(mpdNodes);
        }

        private static void PrintMinimumSpanningTree(List<HouseConnection> mpdNodes)
        {
            for (int i = 0; i < mpdNodes.Count; i++)
            {
                Console.WriteLine("{0}", mpdNodes[i]);
            }
        }

        private static void FindMinimumSpanningTree(bool[] used, SortedSet<HouseConnection> priority, List<HouseConnection> mpdEdges, List<HouseConnection> edges)
        {
            while (priority.Count > 0)
            {
                HouseConnection edge = priority.Min;
                priority.Remove(edge);

                if (!used[edge.EndHouse])
                {
                    used[edge.EndHouse] = true; // we "visit" this node
                    mpdEdges.Add(edge);
                    AddEdges(edge, edges, mpdEdges, priority, used);
                }
            }
        }

        private static void AddEdges(HouseConnection edge, List<HouseConnection> edges, List<HouseConnection> mpd, SortedSet<HouseConnection> priority, bool[] used)
        {
            for (int i = 0; i < edges.Count; i++)
            {
                if (!mpd.Contains(edges[i]))
                {
                    if (edge.EndHouse == edges[i].StartHouse && !used[edges[i].EndHouse])
                    {
                        priority.Add(edges[i]);
                    }
                }
            }
        }
    }
}