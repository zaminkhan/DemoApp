using MVCandAngular.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCandAngular.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetAll()
        {
            using (TestDBEntities1 contextObj = new TestDBEntities1())
            {
                var employeeList = contextObj.Employees.ToList();
                return Json(employeeList, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetEmployeeById(string id)
        {
            using (TestDBEntities1 contextObj = new TestDBEntities1())
            {
                int Id = Convert.ToInt32(id);
                var getEmployeeById = contextObj.Employees.Find(Id);
                return Json(getEmployeeById, JsonRequestBehavior.AllowGet);
            }
        }

        public string UpdateEmployee(EmployeeModal emp)
        {
            if (emp != null)
            {
                using (TestDBEntities1 contextObj = new TestDBEntities1())
                {
                    int empId = Convert.ToInt32(emp.Id);
                    Employee employee = contextObj.Employees.Where(a => a.Id == empId).FirstOrDefault();
                    employee.Name = emp.Name;
                    employee.Department = emp.Department;
                    employee.Address = emp.Address;
                    employee.Dob = emp.Dob;
                    employee.Doj = emp.Doj;
                    employee.Salary = emp.Salary;
                    contextObj.SaveChanges();
                    return "Employee Updated";
                }
            }
            else
            {
                return "Invalid Record";
            }
        }

        public string AddEmployee(EmployeeModal emp)
        {
            if (emp != null)
            {
                using (TestDBEntities1 contextObj = new TestDBEntities1())
                {
                    Employee employee = new Employee();
                    employee.Name = emp.Name;
                    employee.Department = emp.Department;
                    employee.Address = emp.Address;
                    employee.Dob = emp.Dob;
                    employee.Doj = emp.Doj;
                    employee.Salary = emp.Salary;

                    contextObj.Employees.Add(employee);
                    contextObj.SaveChanges();
                    return "Employee Added";
                }
            }
            else
            {
                return "Invalid Record";
            }
        }

        public string DeleteEmployee(string employeeId)
        {

            if (!String.IsNullOrEmpty(employeeId))
            {
                try
                {
                    int Id = Int32.Parse(employeeId);
                    using (TestDBEntities1 contextObj = new TestDBEntities1())
                    {
                        var getEmployee = contextObj.Employees.Find(Id);
                        contextObj.Employees.Remove(getEmployee);
                        contextObj.SaveChanges();
                        return "Employee Deleted";
                    }
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
            else
            {
                return "Invalid Request";
            }
        }

        public ActionResult datepicker()
        {
            return View();
        }

        public ActionResult login()
        {
            return View();
        }

        public ActionResult toaster()
        {
            return View();
        }
    }
}
