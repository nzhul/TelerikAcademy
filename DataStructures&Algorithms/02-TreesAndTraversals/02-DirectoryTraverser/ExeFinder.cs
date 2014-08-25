namespace DirectoryTraverser
{
    using System;
    using System.IO;
    using System.Text;

    public class ExeFinder
    {
        public void GetSubDirectories(string path)
        {
            try
            {
                this.PrintExeFiles(path);

                string[] directories = Directory.GetDirectories(path);

                if (directories.Length > 0)
                {
                    for (int i = 0; i < directories.Length; i++)
                    {
                        this.GetSubDirectories(directories[i]);
                    }
                }
                else
                {
                    return;
                }
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Directory: {0} CANNOT be accessed!", path);
                return;
            }
        }

        private void PrintExeFiles(string path)
        {
            StringBuilder output = new StringBuilder();
            string[] exes = Directory.GetFiles(path, @"*.exe");

            for (int i = 0; i < exes.Length; i++)
            {
                output.AppendLine(exes[i]);
            }

            Console.WriteLine(output.ToString());
        }
    }
}
