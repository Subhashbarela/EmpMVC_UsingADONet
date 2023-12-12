using BussinessLayer.Interfaces;
using CommonLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;

namespace EmpPayRoll_UsingADONet.Controllers
{
    public class SampleController : Controller
    {
       
    //        private readonly IEmployeeBL _empBL;

    //        public EmployeeController(IEmployeeBL empBL)
    //        {
    //            _empBL = empBL;
    //        }
    //        public IActionResult Index()
    //        {
    //            List<Employee> empList = new List<Employee>();
    //            empList = _empBL.GetAllEmployees().ToList();
    //            return View(empList);
    //        }

    //        public IActionResult Create()
    //        {
    //            return View();
    //        }
    //        [HttpPost]
    //        [ValidateAntiForgeryToken]
    //        public IActionResult Create([Bind] Employee employee)
    //        {
    //            if (ModelState.IsValid)
    //            {
    //                _empBL.AddEmployee(employee);

    //                return RedirectToAction("Index");

    //            }
    //            return View(employee);
    //        }
    //        [HttpGet]
    //        public IActionResult Details(int id)
    //        {
    //            var empId = (int)HttpContext.Session.GetInt32("EmployeeId");
    //            var empName = HttpContext.Session.GetString("EmployeeName");
    //            if (empId != 0 && empName != null)
    //            {
    //                if (empId == 2 && empName == "Subhash Barela")
    //                {
    //                    return RedirectToAction("Index");
    //                }

    //                var result = _empBL.GetEmployeeById(empId);
    //                if (result == null)
    //                {
    //                    return NotFound("Data can't found");
    //                }
    //                return View(result);
    //            }
    //            else
    //            {
    //                return RedirectToAction("Login");
    //            }
    //        }
    //        [HttpGet]
    //        public IActionResult Edit(int? id)
    //        {
    //            try
    //            {
    //                // Check if the user is authenticated
    //                if (User.Identity.IsAuthenticated)
    //                {
    //                    // Retrieve the username from the session or claims
    //                    var username = User.Identity.Name;

    //                    // Check if the user has the necessary permissions to edit
    //                    if (_empBL.CanEditEmployee(id, username))
    //                    {
    //                        // Proceed with the edit action
    //                        if (id == null)
    //                        {
    //                            return NotFound();
    //                        }
    //                        Employee employee = _empBL.GetEmployeeById(id);

    //                        if (employee == null)
    //                        {
    //                            return NotFound("Data can't be found");
    //                        }

    //                        return View(employee);
    //                    }
    //                    else
    //                    {
    //                        // User doesn't have permission
    //                        return Forbid(); // or return some other appropriate result
    //                    }
    //                }
    //                else
    //                {
    //                    // User is not authenticated, redirect to login
    //                    return RedirectToAction("Login");
    //                }
    //            }
    //            catch (Exception ex)
    //            {
    //                return NotFound("An error occurred while processing your request." + ex);
    //            }
    //        }
    //        [HttpPost]
    //        [ValidateAntiForgeryToken]
    //        public IActionResult Edit(int id, [Bind] Employee employee)
    //        {
    //            try
    //            {
    //                // Check if the user is authenticated
    //                if (User.Identity.IsAuthenticated)
    //                {
    //                    // Retrieve the username from the session or claims
    //                    var username = User.Identity.Name;

    //                    // Check if the user has the necessary permissions to edit
    //                    if (_empBL.CanEditEmployee(id, username))
    //                    {
    //                        // Proceed with the edit action
    //                        if (id != employee.EmployeeId)
    //                        {
    //                            return NotFound();
    //                        }

    //                        if (ModelState.IsValid)
    //                        {
    //                            bool valid = _empBL.UpdateEmployee(employee);

    //                            if (valid)
    //                            {
    //                                TempData["SuccessMessage"] = "Employee updated successfully!";
    //                                return RedirectToAction("Index");
    //                            }
    //                            else
    //                            {
    //                                return NotFound("Data cannot be updated");
    //                            }
    //                        }

    //                        return View(employee);
    //                    }
    //                    else
    //                    {
    //                        // User doesn't have permission
    //                        return Forbid(); // or return some other appropriate result
    //                    }
    //                }
    //                else
    //                {
    //                    // User is not authenticated, redirect to login
    //                    return RedirectToAction("Login");
    //                }
    //            }
    //            catch (Exception ex)
    //            {
    //                return NotFound("An error occurred while processing your request." + ex);
    //            }
    //        }

    //        [HttpGet]
    //        public IActionResult Delete(int? id)
    //        {
    //            if (id != null)
    //            {
    //                // Retrieve the employee details from the database based on the id
    //                Employee employee = _empBL.GetEmployeeById(id);

    //                // Check if the employee exists and if the user has permission to delete
    //                if (employee != null && _empBL.CanEditEmployee(id, User.Identity.Name))
    //                {
    //                    return View(employee);
    //                }
    //                else
    //                {
    //                    return Forbid(); // or return some other appropriate result
    //                }
    //            }
    //            else
    //            {
    //                return RedirectToAction("Login");
    //            }
    //        }

    //        [HttpPost, ActionName("Delete")]
    //        [ValidateAntiForgeryToken]
    //        public IActionResult DeleteConfirmed(int? id)
    //        {
    //            // Check if the user has permission to delete
    //            if (id != null && _empBL.CanEditEmployee(id, User.Identity.Name))
    //            {
    //                _empBL.DeleteEmployee(id);
    //                return RedirectToAction("Index");
    //            }
    //            else
    //            {
    //                return Forbid(); // or return some other appropriate result
    //            }
    //        }

    //        public IActionResult Login()
    //        {
    //            var loginVar = new EmployeeLogin();
    //            return View(loginVar);
    //        }
    //        [HttpPost]
    //        public IActionResult Login([Bind] EmployeeLogin login)
    //        {
    //            if (!ModelState.IsValid)
    //            {
    //                var result = _empBL.EmployeeLoginDetails(login);
    //                if (result != null)
    //                {
    //                    HttpContext.Session.SetInt32("EmployeeId", result.EmployeeId);
    //                    HttpContext.Session.SetString("EmployeeName", result.EmployeeName);
    //                    return RedirectToAction("Index");
    //                }
    //                return View(login);
    //            }
    //            return View(login);
    //        }
    //    }
    }
}
