using System.IO;
namespace FileTree
{
    public class Program
    {
        static void Main()
        {
            System.Console.WriteLine(Traverse(@"../../"));
        }

        static Folder Traverse(string root)
        {
            var folder = new Folder(root);

            foreach (string file in Directory.GetFiles(root))
            {
                folder.AddFile(new File(file, new FileInfo(file).Length));
            }

            foreach (string directory in Directory.GetDirectories(root))
            {
                folder.AddFolder(Traverse(directory));
            }

            return folder;

        }
    }
}
