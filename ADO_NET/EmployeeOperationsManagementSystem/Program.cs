using System;
using System.Data;
using Microsoft.Data.SqlClient;

class Program
{
    static void Main()
    {
        Console.Write("Enter Department: ");
        string dept = Console.ReadLine();

        Console.WriteLine("\nEmployees:");
        GetEmployeesByDepartment(dept);

        Console.WriteLine("\nDepartment Count:");
        GetDepartmentCount(dept);

        Console.WriteLine("\nEmployee Orders:");
        GetEmployeeOrders();

        Console.WriteLine("\nDuplicate Employees:");
        GetDuplicateEmployees();
    }

    //connection string to connect to the SQL Server database
    static string cs = "Data Source=LAPTOP-LE8UEN24\\SQLEXPRESS;" +
                             "DataBase=ADO_NET;" +
                             "Integrated Security=True;" +
                             "TrustServerCertificate=True;";
    //method to get employees by department using a stored procedure
    static void GetEmployeesByDepartment(string dept)
    {
        using (SqlConnection con = new SqlConnection(cs))
        {
            SqlCommand cmd = new SqlCommand("sp_GetEmployeesByDepartment", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Department", dept);

            con.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine($"{reader["EmpId"]} - {reader["Name"]} - {reader["Department"]}");
            }
        }
    }
    //method to get employee orders using a stored procedure
    static void GetEmployeeOrders()
    {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("sp_GetEmployeeOrders", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine(
                        $"{reader["Name"]} | {reader["Department"]} | " +
                        $"{reader["OrderId"]} | {reader["OrderAmount"]} | {reader["OrderDate"]}"
                    );
                }
            }
    }
    //method to get the count of employees in a department using a stored procedure with an output parameter
    static void GetDepartmentCount(string dept)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("sp_GetDepartmentEmployeeCount", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Department", dept);

                SqlParameter outputParam = new SqlParameter("@TotalEmployees", SqlDbType.Int);
                outputParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(outputParam);

                con.Open();
                cmd.ExecuteNonQuery();

                Console.WriteLine($"Total employees in {dept}: {outputParam.Value}");
            }
        }
    //method to get duplicate employees using a stored procedure
    static void GetDuplicateEmployees()
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("sp_GetDuplicateEmployees", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine($"{reader["EmpId"]} - {reader["Name"]} - {reader["Phone"]} - {reader["Email"]}");
                }
            }
        }
    
}