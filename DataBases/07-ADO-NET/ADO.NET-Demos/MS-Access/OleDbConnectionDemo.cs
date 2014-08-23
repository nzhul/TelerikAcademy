using System;
using System.Data.OleDb;

class OleDbConnectionDemo
{
    static void Main()
    {
        string connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;" +
            @"Data Source=..\..\Library.mdb;Persist Security Info=False";

        OleDbConnection dbConn = new OleDbConnection(connectionString);

        // Open connection
        dbConn.Open();
        using (dbConn)
        {
            OleDbCommand cmd = new OleDbCommand(
                "INSERT INTO Users ([username], [password]) VALUES (@user, @pass)", dbConn);

            cmd.Parameters.AddWithValue("@user", "new user name");
            cmd.Parameters.AddWithValue("@pass", "secret password");

            // Execute command
            try
            {
                //cmd.Parameters["@user"].Value = "tooooooooooooooooooooooooooooooooooo long user name";
				cmd.ExecuteNonQuery();

                Console.WriteLine("Row inserted successfully.");
            }
            catch (OleDbException exception)
            {
                Console.WriteLine("SQL Error occured: " + exception);
            }
        }
    }
}
