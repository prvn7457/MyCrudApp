using Microsoft.AspNetCore.Mvc;
using MyCrudApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCrudApp.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeDbContext DbContext;
        public EmployeeController(EmployeeDbContext dbContext)
        {
            DbContext = dbContext; 
        }
        public IActionResult Index()
        {
            var data = DbContext.Employees.ToList();
            return View(data);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee model)
        {
            var emp = new Employee()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Mobile = model.Mobile,
                Department = model.Department,
                Gender = model.Gender,
                IsActive=model.IsActive
            };
            DbContext.Employees.Add(emp);
            DbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var emps = DbContext.Employees.SingleOrDefault(e => e.Id == id);
            var emp = new Employee()
            {
                FirstName = emps.FirstName,
                LastName = emps.LastName,
                Email = emps.Email,
                Mobile = emps.Mobile,
                Department = emps.Department,
                Gender = emps.Gender,
                IsActive = emps.IsActive
            };
            return View(emp);
        }
        [HttpPost]
        public IActionResult Edit(Employee model)
        {
            var emp = new Employee()
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Mobile = model.Mobile,
                Department = model.Department,
                Gender = model.Gender,
                IsActive = model.IsActive
            };
            DbContext.Employees.Update(emp);
            DbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var emp = DbContext.Employees.SingleOrDefault(e => e.Id == id);
            if(emp != null)
            {
                DbContext.Employees.Remove(emp);
                DbContext.SaveChanges();
                TempData["Error"] = "User deleted !";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["error"] = "User not found !";
                return RedirectToAction("Index");
            }
        }
    }
}
