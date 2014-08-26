namespace CreateJPGFiles
{
    using System;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.IO;
    class Program
    {
        const int OleMetaFilePictStartPosition = 78;
        static void Main()
        {
            // Please change the connection string with Your Own 
            // Check the database Name too!!!
            string connectionString = "Server=LENOVO\\SQLEXPRESS; Database=NORTHWND; Integrated Security=true";
            SqlConnection dbCon = new SqlConnection(connectionString);
            dbCon.Open();

            using (dbCon)
            {
                SqlCommand command = new SqlCommand("SELECT Picture FROM Categories", dbCon);
                var reader = command.ExecuteReader();
                using (reader)
                {
                    Console.WriteLine("CREATING IMAGES:");
                    Console.WriteLine("---------------");
                    int counter = 1;
                    while (reader.Read())
                    {
                        byte[] currentImageData = (byte[])reader["Picture"];
                        GenerateFileFromByteArray("../../image-" + counter.ToString(), currentImageData, ".jpg");
                        Console.WriteLine("{0} -> CREATED", "image-" + counter + "jpg");
                        counter++;
                    }
                    Console.WriteLine("\nPROGRAM COMPLETE -> CHECK THE ROOT FOLDER!\n");
                }
            }
        }

        static void GenerateFileFromByteArray(string fileName, byte[] imageBinaryData, string format)
        {
            MemoryStream memoryStream =
                new MemoryStream(imageBinaryData, OleMetaFilePictStartPosition, imageBinaryData.Length - OleMetaFilePictStartPosition);

            using (memoryStream)
            {
                using (Image image = Image.FromStream(memoryStream))
                {
                    image.Save(fileName + format);
                }
            }
        }
    }
}
