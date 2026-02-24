using Microsoft.Data.SqlClient;
using System;
using System.Data;
using TopBrains_ADO_NET;

class Program
{
    //connection string to connect to the SQL Server database
    static string cs = "Data Source=LAPTOP-LE8UEN24\\SQLEXPRESS;" +
                             "DataBase=ADO_NET;" +
                             "Integrated Security=True;" +
                             "TrustServerCertificate=True;";

    static void Main()
    {
        //Q5: Insert Student Record Using Parameterized Query
        //Console.Write("Enter Id: ");
        //int id = int.Parse(Console.ReadLine());
        //Console.Write("Enter Name: ");
        //string name = Console.ReadLine();
        //Console.Write("Enter Marks: ");
        //int marks = int.Parse(Console.ReadLine());

        //InsertStudent(id, name, marks);

        //Q6:Read Product Table Using DataReader
        //List<Product> products = GetProducts();

        //foreach (var p in products)
        //{
        //    Console.WriteLine($"{p.ProductId} - {p.ProductName} - {p.Price} - {p.Stock}");
        //}

        //Q7: Call Stored Procedure with OUTPUT Parameter
        GetTotalEmployeeCount();
        //q8: Implement Transaction for Fund Transfer
        TransferAmount(1, 2, 1000);


    }

    //Q5: Insert Student Record Using Parameterized Query
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
    //Q6:Read Product Table Using DataReader
    static List<Product> GetProducts()
    {
        List<Product> productList = new List<Product>();

        using (SqlConnection con = new SqlConnection(cs))
        {
            string query = "SELECT ProductId, ProductName, Price, Stock FROM Products";

            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                con.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Product product = new Product
                        {
                            ProductId = reader.GetInt32(0),
                            ProductName = reader.GetString(1),
                            Price = reader.GetDecimal(2),
                            Stock = reader.GetInt32(3)
                        };

                        productList.Add(product);
                    }
                }
            }
        }

        return productList;
    }
    //Q7: Call Stored Procedure with OUTPUT Parameter
    static void GetTotalEmployeeCount()
    {
        using (SqlConnection con = new SqlConnection(cs))
        using (SqlCommand cmd = new SqlCommand("sp_GetTotalEmployeeCount", con))
        {
            cmd.CommandType = CommandType.StoredProcedure;

            // Create OUTPUT parameter
            SqlParameter outputParam = new SqlParameter("@TotalCount", SqlDbType.Int);
            outputParam.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(outputParam);

            con.Open();
            cmd.ExecuteNonQuery();

            Console.WriteLine($"Employee Count: {outputParam.Value}");
        }
    }
    //Q8: Implement Transaction for Fund Transfer
    static void TransferAmount(int senderId, int receiverId, decimal amount)
    {
        using (SqlConnection con = new SqlConnection(cs))
        {
            con.Open();
            SqlTransaction transaction = con.BeginTransaction();

            try
            {
                SqlCommand deductCmd = new SqlCommand(
                    "UPDATE Accounts SET Balance = Balance - @Amount WHERE AccountId = @SenderId",
                    con, transaction);

                deductCmd.Parameters.AddWithValue("@Amount", amount);
                deductCmd.Parameters.AddWithValue("@SenderId", senderId);

                deductCmd.ExecuteNonQuery();

                SqlCommand addCmd = new SqlCommand(
                    "UPDATE Accounts SET Balance = Balance + @Amount WHERE AccountId = @ReceiverId",
                    con, transaction);

                addCmd.Parameters.AddWithValue("@Amount", amount);
                addCmd.Parameters.AddWithValue("@ReceiverId", receiverId);

                addCmd.ExecuteNonQuery();

                transaction.Commit();
                Console.WriteLine("Transaction Successful!");
            }
            catch (Exception ex)
            {
               
                transaction.Rollback();
                Console.WriteLine("Transaction Failed");
                Console.WriteLine("Rolled Back Successfully");
                Console.WriteLine(ex.Message);
            }
        }
    }
}