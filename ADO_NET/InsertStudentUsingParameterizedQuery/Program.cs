using System;
using System.Data;
using Microsoft.Data.SqlClient;

class Program
{
    static string cs = @"Data Source=.\SQLEXPRESS;
                         Initial Catalog=ADO_NET;
                         Integrated Security=True;
                         TrustServerCertificate=True;";

    static void Main()
    {
        Console.Write("Enter Id: ");
        int id = int.Parse(Console.ReadLine());

        Console.Write("Enter Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter Marks: ");
        int marks = int.Parse(Console.ReadLine());

        InsertStudent(id, name, marks);
    }

    static void InsertStudent(int id, string name, int marks)
    {
        using (SqlConnection con = new SqlConnection(cs))
        {
            string query = "INSERT INTO Students1 (Id, Name, Marks) VALUES (@Id, @Name, @Marks)";

            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                // Parameterized query
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;
                cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 100).Value = name;
                cmd.Parameters.Add("@Marks", SqlDbType.Int).Value = marks;

                con.Open();

                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                    Console.WriteLine("Inserted Successfully");
                else
                    Console.WriteLine("Insertion Failed");
            }
        }
    }
}