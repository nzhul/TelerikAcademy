using System;
using System.Data.SqlClient;

class CommandAndDataReader
{
    static void Main()
    {
        SqlConnection dbCon = new SqlConnection("Server=LENOVO\\SQLEXPRESS; " +
            "Database=TelerikAcademy; Integrated Security=true");
        dbCon.Open();
        using (dbCon)
        {
            SqlCommand cmdCount = new SqlCommand(
                "SELECT COUNT(*) FROM Employees", dbCon);
            int employeesCount = (int)cmdCount.ExecuteScalar();
            Console.WriteLine("Employees count: {0} ", employeesCount);
            Console.WriteLine();

            Console.WriteLine("The most senior 10 employees:");
            SqlCommand cmdAllEmployees = new SqlCommand(
              "SELECT TOP 10 * FROM Employees ORDER BY HireDate", dbCon);
            SqlDataReader reader = cmdAllEmployees.ExecuteReader();
            using (reader)
            {
                while (reader.Read())
                {
                    string firstName = (string)reader["FirstName"];
                    string lastName = (string)reader["LastName"];
                    decimal salary = (decimal)reader["Salary"];
                    Console.WriteLine("{0} {1} - {2}", firstName, lastName, salary);
                }
            }
        }
    }
}
