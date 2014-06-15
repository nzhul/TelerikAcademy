using System;

namespace CohesionAndCoupling
{
    class FileUtils
    {
        public static string GetFileExtension(string fileName)
        {
            if (!fileName.Contains("."))
                return String.Empty;

            return fileName.Substring(fileName.LastIndexOf("."));
        }

        public static string GetFileNameWithoutExtension(string fileName)
        {
            if (!fileName.Contains("."))
                return fileName;

            return fileName.Substring(0, fileName.LastIndexOf("."));
        }
    }
}