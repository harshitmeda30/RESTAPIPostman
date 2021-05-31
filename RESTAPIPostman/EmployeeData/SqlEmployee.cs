using RESTAPIPostman.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RESTAPIPostman.EmployeeData
{
    public class SqlEmployee : IEmployee
    {
        EmployeeContext _empcontext;
        public SqlEmployee(EmployeeContext empcontext)
        {
            _empcontext = empcontext;
        }
        public Employee AddEmployee(Employee employee)
        {
            employee.Id = Guid.NewGuid();
            _empcontext.Emps.Add(employee);
            _empcontext.SaveChanges();
            return employee;
        }

        public void DeleteEmployee(Employee employee)
        {
            if (_empcontext.Emps.Find(employee.Id) != null)
            {
                _empcontext.Emps.Remove(employee);
                _empcontext.SaveChanges();
                //return Ok();
            }
            //return 
        }

        public Employee EditEmployee(Employee employee)
        {
            //Employee removeemp = _empcontext.Emps.Find(employee.Id);
            if (_empcontext.Emps.Find(employee.Id) != null)
            {
                var removeemp = _empcontext.Emps.Find(employee.Id);
                _empcontext.Emps.Remove(removeemp);
                //_empcontext.SaveChanges();
                _empcontext.Emps.Update(employee);
                _empcontext.SaveChanges();
            
            }
            return employee;
        }

        public Employee GetEmployee(Guid id)
        {
            return _empcontext.Emps.Find(id);
        }

        public List<Employee> GetEmployees()
        {
            return _empcontext.Emps.ToList();
        }
    }
}
