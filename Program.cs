using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;

namespace BestBuyDPractices
{
    class Program
    {
        
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connString = config.GetConnectionString("DefaultConnection");
            IDbConnection conn = new MySqlConnection(connString);
            var repo = new DepartmentRepository(conn);
            var departments = repo.GetAllDepartments();
            PrintDepartments(departments);
            
            Console.WriteLine("Please enter the department name you wish to insert into Departments table");
            var newDepartment = Console.ReadLine();
            repo.InsertDepartment(newDepartment);
            departments = repo.GetAllDepartments();
            PrintDepartments(departments);

            /* for product table*/
            Console.WriteLine("Please enter the Product name you wish to insert into Products table");
            var newName = Console.ReadLine();
            Console.WriteLine("Please enter the Product price you wish to insert into Products table");
            var newPrice = double.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the Product category id you wish to insert into Products table");
            var newCategory = int.Parse(Console.ReadLine());

            var prodRepo = new ProductRepository(conn);
            prodRepo.CreateProduct(newName, newPrice, newCategory);
            var products =  prodRepo.GetAllProducts();
            PrintProducts(products);

            void PrintProducts(IEnumerable<Product> products)
            {
                foreach (var prod in products)
                {
                    Console.WriteLine($"{prod.ProductID}  {prod.Name}  {prod.Price}  {prod.CategoryID}");
                }
                    
            }

            void PrintDepartments(IEnumerable<Department> departments)
            {
                foreach (var dept in departments)
                {
                    Console.WriteLine($"{dept.DepartmentID} {dept.Name}");
                }
            }
        }

        
    }
}
