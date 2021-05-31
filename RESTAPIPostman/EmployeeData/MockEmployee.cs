using RESTAPIPostman.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RESTAPIPostman.EmployeeData
{
    public class MockEmployee : IEmployee
    {
        /*private Employee _employee;
        public MockEmployee(Employee employee)
        {
            _employee = employee;
        }*/
        List<Employee> emps = new List<Employee>(){
            new Employee()
            {
                Id=Guid.NewGuid(),
                name="captain"
            },
            new Employee()
            {
                Id=Guid.NewGuid(),
                name="IronMan"
            }
        };

        public Employee AddEmployee(Employee employee)
        {
            employee.Id = Guid.NewGuid();
            emps.Add(employee);
            return emps.SingleOrDefault(x => x.Id == employee.Id);
        }

        public void DeleteEmployee(Employee employee)
        {
            emps.Remove(employee);
        }

        public Employee EditEmployee(Employee Addemployee)
        {
            Employee removeemp = emps.SingleOrDefault(x => x.Id == Addemployee.Id);
            emps.Remove(removeemp);
            emps.Add(Addemployee);
            return Addemployee;
        }

        public Employee GetEmployee(Guid id)
        {
            return emps.SingleOrDefault(x => x.Id == id);
        }

        public List<Employee> GetEmployees()
        {
            return emps;
        }
    }
}
