using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using WebApplication1MVC.Models;

namespace WebApplication1MVC.Controllers
{
    public class EmployeesController : Controller
    {
        // GET: EmployeesController or EmployeesController/Index
        public ActionResult Index() // deisplay all emp
        {
            List<Employees> employees = Employees.GetALLEmployees();

            return View(employees);  
        }

        // GET: EmployeesController/Details/5
        public ActionResult Details(int id)
        {
            Employees e = Employees.GetEmployee(id);

            return View(e);
        }

        // GET: EmployeesController/Create -> will send form for creating a Employee
        [HttpGet]  // this is optional (Get is default thus we don't need to specify 
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeesController/Create  -> will receiving post request from the form view sent from the the GET Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employees e)
        {
            try
            {   
                Employees.AddEmployee(e);      
                 
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeesController/Edit/5
        public ActionResult Edit(int id)
        {
            Employees e = Employees.GetEmployee(id);
            return View(e);
        }

        // POST: EmployeesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Employees e)
        {
            try
            {
                Employees.UpdateEmployee(e);
                
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeesController/Delete/5
        public ActionResult Delete(int id)
        {
            Employees e = Employees.GetEmployee(id);
            return View(e);
        }

        // POST: EmployeesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                Employees.DeleteEmployee(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
