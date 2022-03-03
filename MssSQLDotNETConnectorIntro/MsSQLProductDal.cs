using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using static MssSQLDotNETConnectorIntro.Program;

namespace MssSQLDotNETConnectorIntro
{
    public class MsSQLProductDal : IProductDal
    {
       

        private SqlConnection SqlConnector(string connection)
        {
            return new SqlConnection(connection);
        }
        public void Create(Product p)
        {
            string connectionString = @"Data Source=DESKTOP-SMI6A2F\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=SSPI;";
            using (var connection = SqlConnector(connectionString))
            {
                try
                {
                    connection.Open();
                    Console.WriteLine("baglanti basarili...");
                    string SqlQuery = "insert into Products(ProductName,UnitPrice) values(@productName,@price)";

                    SqlCommand command = new SqlCommand(SqlQuery, connection);
                    //command.Parameters.Add("@productId", System.Data.SqlDbType.Int).Value = p.ProductId;
                    command.Parameters.Add("@productName", System.Data.SqlDbType.Text).Value = p.ProductName;
                    command.Parameters.Add("@price", System.Data.SqlDbType.Money).Value = p.Price;

                    SqlDataReader reader = command.ExecuteReader();

                    reader.Read();

                    Console.WriteLine("Urun eklendi...");



                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }

        public void Delete(int id)
        {
            string connectionString = @"Data Source=DESKTOP-SMI6A2F\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=SSPI;";
            using (var connection = SqlConnector(connectionString))
            {
                try
                {
                    connection.Open();
                    Console.WriteLine("baglanti basarili...");
                    string SqlQuery = "delete from Products where ProductID=@productId;";

                    SqlCommand command = new SqlCommand(SqlQuery, connection);
                    //command.Parameters.Add("@productId", System.Data.SqlDbType.Int).Value = p.ProductId;
                    command.Parameters.Add("@productId", System.Data.SqlDbType.Int).Value = productId;

                    SqlDataReader reader = command.ExecuteReader();

                    reader.Read();

                    Console.WriteLine("Urun Silindi...");



                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }

        public List<Product> GetAllProducts()
        {
            List<Product> products = new List<Product>();

            string connectionString = @"Data Source=DESKTOP-SMI6A2F\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=SSPI;";
            using (var connection = SqlConnector(connectionString))
            {
                try
                {
                    connection.Open();
                    Console.WriteLine("baglanti basarili...");
                    string SqlQuery = "select * from Products";

                    SqlCommand command = new SqlCommand(SqlQuery, connection);

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        products.Add(new Product()
                        {
                            ProductId = int.Parse(reader["ProductID"].ToString()),
                            ProductName = reader["ProductName"].ToString()
                        });
                    }
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
            return products;
        }

        public Product GetProductById(int id)
        {
            Product product = null;
            string connectionString = @"Data Source=DESKTOP-SMI6A2F\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=SSPI;";
            using (var connection = SqlConnector(connectionString))
            {
                try
                {
                    connection.Open();
                    Console.WriteLine("baglanti basarili...");
                    string SqlQuery = "select * from Products where ProductID=@productId";

                    SqlCommand command = new SqlCommand(SqlQuery, connection);
                    //Console.WriteLine("girdi!");
                    command.Parameters.Add("@productId", System.Data.SqlDbType.Int).Value = id;

                    SqlDataReader reader = command.ExecuteReader();

                    //Console.WriteLine("girdi 2!");
                    reader.Read();

                    if (reader.HasRows)
                    {
                        //Console.WriteLine("girdi 3");
                        product = new Product()
                        {
                            ProductId = int.Parse(reader["ProductID"].ToString()),
                            ProductName = reader["ProductName"].ToString()
                        };

                    }
                    //Console.WriteLine("girdi 2");

                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }
            return product;
        }

        public void Update(int id, Product p)
        {
            string connectionString = @"Data Source=DESKTOP-SMI6A2F\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=SSPI;";
            using (var connection = SqlConnector(connectionString))
            {
                try
                {
                    connection.Open();
                    Console.WriteLine("baglanti basarili...");
                    string SqlQuery = "update Products set ProductName=@productName, UnitPrice=@price where ProductID = @productId;";

                    SqlCommand command = new SqlCommand(SqlQuery, connection);
                    //command.Parameters.Add("@productId", System.Data.SqlDbType.Int).Value = p.ProductId;
                    command.Parameters.Add("@productName", System.Data.SqlDbType.Text).Value = p.ProductName;
                    command.Parameters.Add("@price", System.Data.SqlDbType.Money).Value = p.Price;
                    command.Parameters.Add("@productId", System.Data.SqlDbType.Int).Value = id;

                    SqlDataReader reader = command.ExecuteReader();

                    reader.Read();

                    Console.WriteLine("Urun Guncellendi...");



                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }
    }
}
