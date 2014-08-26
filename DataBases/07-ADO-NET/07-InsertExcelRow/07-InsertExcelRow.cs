namespace InsertExcelRow
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.OleDb;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Program
    {
        static void Main()
        {
            string excelConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=../../score_db.xlsx;Extended Properties='Excel 12.0 xml;HDR=Yes';";
            var excelConnection = new OleDbConnection(excelConnectionString);
            excelConnection.Open();

            DataTable excelSchema = excelConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            string sheetName = excelSchema.Rows[0]["TABLE_NAME"].ToString();

            Console.Write("Username: ");
            string userName = Console.ReadLine();
            Console.Write("Score: ");
            int score = int.Parse(Console.ReadLine());

            OleDbCommand excelCommand = new OleDbCommand(@"INSERT INTO [" + sheetName + @"]
                                                           VALUES (@name, @score)", excelConnection);

            excelCommand.Parameters.AddWithValue("@name", userName);
            excelCommand.Parameters.AddWithValue("@age", score);

            using (excelConnection)
            {
                Console.WriteLine("\nINSERTING INTO EXCEL FILE DATABASE");
                Console.WriteLine("-----------------------------------\n");
                var queryResult = excelCommand.ExecuteNonQuery();
                Console.WriteLine("({0} row(s) affected)", queryResult);
            }
        }
    }
}
