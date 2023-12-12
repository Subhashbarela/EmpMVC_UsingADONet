using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interfaces
{
    public interface IEmployeeRepo
    {
        public IEnumerable<Employee> GetAllEmployees();
        public void AddEmployee(Employee employee);
        public Employee GetEmployeeById(int? empid);
        public bool UpdateEmployee(Employee emp);
        public void DeleteEmployee(int? empid);
        public Employee EmployeeLoginDetails(EmployeeLogin login);
        public bool CanEditEmployee(int? employeeId, string username);

    }
}
