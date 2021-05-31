using RESTAPIPostman.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RESTAPIPostman.EmployeeData
{
    public interface IEmployee
    {
        List<Employee> GetEmployees();
        Employee GetEmployee(Guid id);
        Employee AddEmployee(Employee employee);
        Employee EditEmployee(Employee employee);
        void DeleteEmployee(Employee employee);

    }
}
