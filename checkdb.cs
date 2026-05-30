using System;
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
        string connStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=QuanLyCuaHangGame;Integrated Security=True";
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand("SELECT MIN(PaidAt), MAX(PaidAt), COUNT(*) FROM Invoices", conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Console.WriteLine($"Min Date: {reader[0]}");
                        Console.WriteLine($"Max Date: {reader[1]}");
                        Console.WriteLine($"Count: {reader[2]}");
                    }
                }
            }
        }
    }
}
