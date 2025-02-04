using System;
using System.Data;
using System.IO;
using DapperDemoCSharp_51.Data;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;

//^^^^MUST HAVE USING DIRECTIVES^^^^
namespace DapperDemoCSharp_51;

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

        var departmentRepo = new DepartmentRepository(conn);
        
        //departmentRepo.AddDepartment("CSharp-51");
        
        // var departments = departmentRepo.GetAllDepartments();
        //
        // foreach (var department in departments)
        // {
        //     Console.WriteLine($"ID: {department.DepartmentID} | Name: {department.Name}");
        // }
        
        var productRepo = new ProductRepository(conn);
        
        //productRepo.CreateProduct("Coding Computer", 1000.00, 1, false, 500);
        //productRepo.UpdateProduct(942, "Video Game", 70.00, 8, true, 400);
        //productRepo.DeleteProduct(942);

        var products = productRepo.GetAllProducts();

        foreach (var product in products)
        {
            Console.WriteLine($"ID: {product.ProductID} | Name: {product.Name} | Price: {product.Price} | Category ID: {product.CategoryID} | Sale: {product.OnSale} | Stock: {product.StockLevel}");
        }
    }
}