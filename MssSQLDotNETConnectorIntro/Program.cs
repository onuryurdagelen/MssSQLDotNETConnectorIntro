using System;
using System.Collections.Generic;
using System.Data.SqlClient;
namespace MssSQLDotNETConnectorIntro
{
    class Program
    {

        public interface IProductDal
        {
            List<Product> GetAllProducts();

            Product GetProductById(int id);

            void Create(Product p);

            void Delete(int id);

            void Update(int id, Product p);
        }

        static void Main(string[] args)
        {

            //var filteredProduct = GetProductById(5);
            //GetProductById(5);

            //Console.WriteLine($"{filteredProduct.ProductName}");
            //GetAllProducts();

            //Create(new Product() { ProductName = "Schwapz Beer",Price= 19.00});
            var productManager = new ProductManager(new MsSQLProductDal());

            var products = productManager.GetAllProducts();

            foreach (var product in products)
            {
                Console.WriteLine(product.ProductName);
            }

            //Delete(78);

          
        }
        
     
        
       
    }
}
