namespace Frames
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    class Program
    {
        static SortedSet<string> result = new SortedSet<string>();
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            var frames = new Frame[n];
            for (int i = 0; i < n; i++)
            {
                int[] sizes = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                frames[i] = new Frame(sizes[0], sizes[1]);
            }

            Perm(frames, 0);

            Console.WriteLine(result.Count);
            var output = new StringBuilder();
            foreach (var frame in result)
            {
                output.AppendLine(frame);
            }

            Console.WriteLine(output.ToString().Trim());
        }

        static void Perm(Frame[] arr, int k)
        {
            if (k >= arr.Length) 
            {
                result.Add(String.Join(" | ", arr));
            }
            else
            {
                Perm(arr, k + 1);
                SwapFrame(ref arr[k]);
                Perm(arr, k + 1);
                SwapFrame(ref arr[k]);
                for (int i = k + 1; i < arr.Length; i++)
                {
                    Swap(ref arr[k], ref arr[i]);
                    Perm(arr, k + 1);
                    SwapFrame(ref arr[k]);
                    Perm(arr, k + 1);
                    SwapFrame(ref arr[k]);
                    Swap(ref arr[k], ref arr[i]);
                }
            }
        }

        static void SwapFrame(ref Frame frame)
        {
            int oldFirst = frame.Width;
            frame.Width = frame.Height;
            frame.Height = oldFirst;
        }

        static void Swap<T>(ref T first, ref T second)
        {
            T oldFirst = first;
            first = second;
            second = oldFirst;
        }

        struct Frame
        {
            public Frame(int width, int height)
                :this()
            {
                this.Width = width;
                this.Height = height;
            }
            public int Width { get; set; }
            public int Height { get; set; }

            public override string ToString()
            {
                return String.Format("({0}, {1})", this.Width, this.Height);
            }

        }

        // Permutation with action
        //static void Perm<T>(T[] arr, int k, Action<T[]> action)
        //{
        //    if (k >= arr.Length)
        //    {
        //        action(arr);
        //    }
        //    else
        //    {
        //        Perm(arr, k + 1, action);
        //        for (int i = k + 1; i < arr.Length; i++)
        //        {
        //            Swap(ref arr[k], ref arr[i]);
        //            Perm(arr, k + 1, action);
        //            Swap(ref arr[k], ref arr[i]);
        //        }
        //    }
        //}
        //
        // Usage in MainMethod:
        // Perm(frames, 0, (x) => Console.WriteLine(x));
    }
}
