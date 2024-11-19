using Microsoft.EntityFrameworkCore;
using SimpleCrud.DataAccess.Entities;
using SimpleCrud.ViewModels;
using SimpleCrud.DataAccess;

namespace SimpleCrud.Services;

public class EmployeeService
{
    private readonly AppDBContext dBContext;
    
    public EmployeeService(AppDBContext dBContext)
    {
        this.dBContext = dBContext;
    }

    public async Task<List<EmployeeViewModel>> GetAllEmployees()
    {
        return await dBContext.Employees.OrderBy(x => x.FullName).Select(x => new EmployeeViewModel
        {
            EmployeeId = x.EmployeeId,
            FullName = x.FullName,
            Department = x.Department,
            DateOfBirth = x.DateOfBirth,
            Age = x.Age,
            PhoneNumber = x.PhoneNumber,
        }).ToListAsync();
    }

    public bool CreateNewEmployee(EmployeeViewModel model)
    {
        try
        {
            Employee employee = new Employee
            {
                FullName = model.FullName,
                Department = model.Department,
                DateOfBirth = model.DateOfBirth,
                Age = model.Age,
                PhoneNumber = model.PhoneNumber,
            };
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}