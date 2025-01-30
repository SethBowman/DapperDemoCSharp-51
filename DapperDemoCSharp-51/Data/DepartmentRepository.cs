using System.Data;
using DapperDemoCSharp_51.Models;
using Dapper;

namespace DapperDemoCSharp_51.Data;

public class DepartmentRepository : IDepartmentRepository
{
    private readonly IDbConnection _connection;

    public DepartmentRepository(IDbConnection connection)
    {
        _connection = connection;
    }
    
    public IEnumerable<Department> GetAllDepartments()
    {
        return _connection.Query<Department>("SELECT * FROM departments;");
    }

    public void AddDepartment(string name)
    {
        _connection.Execute("INSERT INTO departments (Name) VALUES (@name);", new {name});
    }
}