using BussinessLayer.Interfaces;
using CommonLayer.Model;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLayer.Services
{
    public class EmployeeBL:IEmployeeBL
    {
        private readonly IEmployeeRepo _empRepo;

        public EmployeeBL(IEmployeeRepo empRepo)
        {
            _empRepo = empRepo;
        }
        public void AddEmployee(Employee employee)
        {
             _empRepo.AddEmployee(employee);
        }
        public IEnumerable<Employee> GetAllEmployees()
        {
            return _empRepo.GetAllEmployees();
        }

        public Employee GetEmployeeById(int? empid)
        {
            try
            {
                return _empRepo.GetEmployeeById(empid);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error retrieving employee by ID.", ex);
            }
        }
        public bool UpdateEmployee(Employee emp)
        {
            return _empRepo.UpdateEmployee(emp);
        }
        public void DeleteEmployee(int? empid)
        {
            this._empRepo.DeleteEmployee(empid);
        }

        public Employee EmployeeLoginDetails(EmployeeLogin login)
        {
            return this._empRepo.EmployeeLoginDetails(login);
        }
        public bool CanEditEmployee(int? employeeId, string username)
        {
            return this._empRepo.CanEditEmployee(employeeId, username);
        }

       

      
    }
}
