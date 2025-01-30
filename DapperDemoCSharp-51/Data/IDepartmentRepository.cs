using DapperDemoCSharp_51.Models;

namespace DapperDemoCSharp_51.Data;

public interface IDepartmentRepository
{
    public IEnumerable<Department> GetAllDepartments();
    public void AddDepartment(string name);
}