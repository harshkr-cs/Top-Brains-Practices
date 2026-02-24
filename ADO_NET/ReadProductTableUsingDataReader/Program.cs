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
        List<Product> products = GetProducts();

        foreach (var p in products)
        {
            Console.WriteLine($"{p.ProductId} - {p.ProductName} - {p.Price} - {p.Stock}");
        }


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
}