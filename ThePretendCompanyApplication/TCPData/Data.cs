uing System.Collections.Generic;
namespace TCPData;

public static class Data
{
    public static List<Employee> GetEmployees()
    {
        List<Employee> employees = new List<Employee>();
        Employee employee = new Employee
        {
            Id = 1,
            FirstName = "Bob",
            LastName = "Smith",
            AnnualSalary = 6000.3m,
            IsManager = true,
            DepartmentId = 1 
        };
        employees.Add(employee);

        employee = new Employee
        {
            Id = 2,
            FirstName = "Jane",
            LastName = "Doe",
            AnnualSalary = 8000.3m,
            IsManager = false,
            DepartmentId = 2
        };
        employees.Add(employee);
        employee = new Employee
        {
            Id = 3,
            FirstName = "Douglas",
            LastName = "Roberts",
            AnnualSalary = 4000.2m,
            IsManager = true,
            DepartmentId = 2
        };
        employees.Add(employee);

        employee = new Employee
        {
            Id = 4,
            FirstName = "Jane",
            LastName = "Stevens",
            AnnualSalary = 3000.2m,
            IsManager = false,
            DepartmentId = 3
        };
        employees.Add(employee);
        
        return employees;
    }

    public static List<Department> GetDepartments()
    {
        List<Department> departments = new List<Department>();

        Department department = new Department
        {
            Id = 1,
            ShortName = "HR",
            LongName = "Human Resources",
        };
        departments.Add(department);
        department = new Department
        {
            Id = 2,
            ShortName = "FN",
            LongName = "Finance",
        };
        departments.Add(department);
        department = new Department
        {
            Id = 3,
            ShortName = "TE",
            LongName = "Technology",
        };
        departments.Add(department);

        return departments;
    }
}