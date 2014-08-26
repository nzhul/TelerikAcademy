namespace ExcelReader
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

            OleDbCommand excelCommand = new OleDbCommand("SELECT * FROM [" + sheetName + "]", excelConnection);

            using (excelConnection)
            {
                using (OleDbDataAdapter adapter = new OleDbDataAdapter(excelCommand))
                {
                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet);

                    using (DataTableReader reader = dataSet.CreateDataReader())
                    {
                        while (reader.Read())
                        {
                            var userName = reader["Name"];
                            var score = reader["Score"];

                            Console.WriteLine(userName + " -> " + score);
                        }
                    }
                }
            }
        }
    }
}
