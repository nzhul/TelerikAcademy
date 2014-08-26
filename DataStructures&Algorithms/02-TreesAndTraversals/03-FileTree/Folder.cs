namespace FileTree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Folder
    {
        public string Name { get; private set; }
        public List<File> Files { get; private set; }
        public List<Folder> NestedFolders { get; private set; }

        public Folder(string name)
        {
            this.Name = name;
            this.Files = new List<File>();
            this.NestedFolders = new List<Folder>();
        }

        public void AddFile(File file)
        {
            this.Files.Add(file);
        }

        public void AddFolder(Folder folder)
        {
            this.NestedFolders.Add(folder);
        }

        public long GetSize(Folder startingFolder)
        {
            long result = 0;

            foreach (var file in this.Files)
            {
                result += file.Size;
            }

            foreach (var folder in this.NestedFolders)
            {
                result += folder.GetSize(startingFolder);
            }

            return result;
        }

        public override string ToString()
        {
            var result = new List<string>();

            result.AddRange(this.Files.Select(file => file.ToString()));
            result.AddRange(this.NestedFolders.Select(folder => folder.ToString()));

            return String.Join(Environment.NewLine, result);

        } 
    }
}
