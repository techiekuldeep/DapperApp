using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DapperApp.Data;
using DapperApp.Models;
using DapperApp.Repository;

namespace DapperApp.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly ICompanyRepository _compRepo;
        private readonly IEmployeeRepository _empRepo;
        private readonly IBonusRepository _bonusRepo;
        [BindProperty]
        public Employee Employee { get; set; }
        public EmployeesController(ICompanyRepository compRepo, IEmployeeRepository empRepo, IBonusRepository bonusRepo)
        {
            _compRepo = compRepo;
            _bonusRepo = bonusRepo;
            _empRepo = empRepo;
        }
        //Index method with N+1 call
        //public async Task<IActionResult> Index()
        //{
        //    List<Employee> employees = _empRepo.GetAll();
        //    foreach (Employee obj in employees)
        //    {
        //        obj.Company = _compRepo.Find(obj.CompanyId);
        //    }

        //    return View(employees);
        //}

        //Index method with N+1 call resolution using Bonus repository
        public async Task<IActionResult> Index(int companyId = 0)
        {
            List<Employee> employees = _bonusRepo.GetEmployeeWithCompany(companyId);
            return View(employees);
        }


        public IActionResult Create()
        {
            IEnumerable<SelectListItem> companyList = _compRepo.GetAll().Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.CompanyId.ToString()
            });
            ViewBag.CompanyList = companyList;
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Create")]
        public async Task<IActionResult> CreatePOST()
        {
            if (ModelState.IsValid)
            {
                _empRepo.Add(Employee);
                return RedirectToAction(nameof(Index));
            }
            return View(Employee);
        }

   
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Employee = _empRepo.Find(id.GetValueOrDefault());
            IEnumerable<SelectListItem> companyList = _compRepo.GetAll().Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.CompanyId.ToString()
            });
            ViewBag.CompanyList = companyList;
            if (Employee == null)
            {
                return NotFound();
            }
            return View(Employee);
        }

    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id)
        {
            if (id != Employee.EmployeeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _empRepo.Update(Employee);
                return RedirectToAction(nameof(Index));
            }
            return View(Employee);
        }

        
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            _empRepo.Remove(id.GetValueOrDefault());
            return RedirectToAction(nameof(Index));
        }  
    }
}
