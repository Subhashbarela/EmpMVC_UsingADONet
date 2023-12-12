using CommonLayer.Model;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace RepositoryLayer.Services
{
    public class EmployeeRepo : IEmployeeRepo
    {
        private readonly IConfiguration _configuration;

        public EmployeeRepo(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void AddEmployee(Employee employee)
        {
            SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("DefaultConn"));

            try
            {
                SqlCommand cmd = new SqlCommand("spAddEmployee", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmployeeName", employee.EmployeeName);
                cmd.Parameters.AddWithValue("@ProfileImage", employee.ProfileImage);
                cmd.Parameters.AddWithValue("@Department", employee.Department);
                cmd.Parameters.AddWithValue("@Gender", employee.Gender);
                cmd.Parameters.AddWithValue("@Salary", employee.Salary);
                cmd.Parameters.AddWithValue("@StartDate", employee.StartDate);
                cmd.Parameters.AddWithValue("@Notes", employee.Notes);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            try
            {
                List<Employee> empList = new List<Employee>();
                SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("DefaultConn"));
                conn.Open();
                SqlCommand cmd = new SqlCommand("spGetAllEmployees", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Employee emp = new Employee();
                    emp.EmployeeId = Convert.ToInt32(dr["EmployeeId"]);
                    emp.EmployeeName = dr["EmployeeName"].ToString();
                    emp.ProfileImage = dr["ProfileImage"].ToString();
                    emp.Department = dr["Department"].ToString();
                    emp.Gender = dr["Gender"].ToString();
                    emp.Salary = Convert.ToInt64(dr["Salary"]);
                    emp.StartDate = Convert.ToDateTime(dr["StartDate"]);
                    emp.Notes = dr["Notes"].ToString();
                    empList.Add(emp);
                }
                conn.Close();
                return empList;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public Employee GetEmployeeById(int? empid)
        {
            Employee emp = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("DefaultConn")))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand("spGetEmployeesById", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@EmployeeId", empid);

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            emp = new Employee();
                            while (dr.Read())
                            {
                                emp.EmployeeId = Convert.ToInt32(dr["EmployeeId"]);
                                emp.EmployeeName = dr["EmployeeName"].ToString();
                                emp.ProfileImage = dr["ProfileImage"].ToString();
                                emp.Department = dr["Department"].ToString();
                                emp.Gender = dr["Gender"].ToString();
                                emp.Salary = Convert.ToInt64(dr["Salary"]);
                                emp.StartDate = Convert.ToDateTime(dr["StartDate"]);
                                emp.Notes = dr["Notes"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error retrieving employee by ID. See the log for details.", ex);
            }
            return emp;
        }
        public bool UpdateEmployee(Employee emp)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DefaultConn"));
            try
            {
                SqlCommand cmd = new SqlCommand("spUpdateEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EmployeeId", emp.EmployeeId);
                cmd.Parameters.AddWithValue("@EmployeeName", emp.EmployeeName);
                cmd.Parameters.AddWithValue("@ProfileImage", emp.ProfileImage);
                cmd.Parameters.AddWithValue("@Department", emp.Department);
                cmd.Parameters.AddWithValue("@Gender", emp.Gender);
                cmd.Parameters.AddWithValue("@Salary", emp.Salary);
                cmd.Parameters.AddWithValue("@StartDate", emp.StartDate);
                cmd.Parameters.AddWithValue("@Notes", emp.Notes);

                con.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error updating employee by ID. See the log for details.", ex);
            }
            finally
            {
                con.Close();
            }
        }
        public void DeleteEmployee(int? empid)
        {

            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DefaultConn"));
            try
            {
                SqlCommand cmd = new SqlCommand("spDeleteEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EmployeeId", empid);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Employee EmployeeLoginDetails(EmployeeLogin login)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DefaultConn"));
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("spEmployeeLogin", con);
                cmd.CommandType= CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmpLoginId", login.EmpLoginId);
                cmd.Parameters.AddWithValue("@EmpLoginName",login.EmpLoginName);
                var returnParameter = cmd.Parameters.Add("result", SqlDbType.Int);
                returnParameter.Direction= ParameterDirection.ReturnValue;

                Employee employee = new Employee();
                SqlDataReader dr= cmd.ExecuteReader();
                var result = returnParameter.Value;

                if(result !=null && result.Equals(2))
                {
                    throw new Exception("Invalid Employee Id and UserName");
                }
                while(dr.Read())
                {
                    employee.EmployeeId = Convert.ToInt32(dr["EmployeeId"]);
                    employee.EmployeeName = dr["EmployeeName"].ToString();
                    employee.ProfileImage = dr["ProfileImage"].ToString();
                    employee.Department = dr["Department"].ToString();
                    employee.Gender = dr["Gender"].ToString();
                    employee.Salary = Convert.ToInt64(dr["Salary"]);
                    employee.StartDate = Convert.ToDateTime(dr["StartDate"]);
                    employee.Notes = dr["Notes"].ToString();
                }
                return employee;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Employee data does not match"+ ex.Message);
            }
        }
        public bool CanEditEmployee(int? employeeId, string username)
        {
           
            Employee employee = GetEmployeeById(employeeId);

            if (employee != null && employee.EmployeeName == username)
            {

                return true; // User has permission to edit
            }

            return false; // User does not have permission to edit
        }
    }
}
