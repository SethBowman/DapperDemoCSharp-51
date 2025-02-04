using System.Data;
using Dapper;
using DapperDemoCSharp_51.Models;

namespace DapperDemoCSharp_51.Data;

public class ProductRepository : IProductRepository
{
    private readonly IDbConnection _connection;

    public ProductRepository(IDbConnection connection)
    {
        _connection = connection;
    }
    
    public IEnumerable<Product> GetAllProducts()
    {
        return _connection.Query<Product>("SELECT * FROM products;");
    }

    public void UpdateProduct(int productId, string newName, double newPrice, int categoryId, bool onSale, int stockLevel)
    {
        _connection.Execute("UPDATE products SET Name = @newName, Price = @newPrice, CategoryID = @categoryId, OnSale = @onSale, StockLevel = @stockLevel WHERE ProductID = @productId;",
            new { newName, newPrice, categoryId, onSale, stockLevel, productId});
    }

    public void CreateProduct(string name, double price, int categoryId, bool onSale, int stockLevel)
    {
        _connection.Execute("INSERT INTO products (Name, Price, CategoryID, OnSale, StockLevel) VALUES (@name, @price, @categoryId, @onSale, @stockLevel);",
            new {name, price, categoryId, onSale, stockLevel});
    }

    public void DeleteProduct(int productId)
    {
        _connection.Execute("DELETE FROM reviews WHERE ProductID = @productId;", new {productId});
        _connection.Execute("DELETE FROM sales WHERE ProductID = @productId;", new {productId});
        _connection.Execute("DELETE FROM products WHERE ProductID = @productId;", new {productId});
    }
}