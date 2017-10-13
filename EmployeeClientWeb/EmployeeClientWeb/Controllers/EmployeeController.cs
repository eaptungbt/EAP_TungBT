using EmployeeClientWeb.EmployeeService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeClientWeb.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeNewClient client = new EmployeeNewClient();
        // GET: Employee
        public ActionResult Index()
        {
            ViewBag.listEmployee = client.GetProductList();
            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Employee emp)
        {
            client.AddEmployee(emp);
            return RedirectToAction("Index", "Employee");
        }
        public ActionResult Delete(string id)
        {
            client.DeleteEmployee(id);
            return RedirectToAction("Index", "Employee");
        }
        public ActionResult Edit(string id)
        {
            var emp = client.GetProductList().Where(e => e.empID == id).FirstOrDefault();
            return View(emp);
        }
        [HttpPost]
        public ActionResult Edit(Employee emp)
        {
            client.UpdateEmployee(emp);
            return RedirectToAction("Index", "Employee");
        }
    }
}