using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Data;
using SalesWebMvc.Models;
using SalesWebMvc.Services;

namespace SalesWebMvc.Controllers
{
    public class DepartmentsController : Controller
    {
        private readonly DepartmentService _departmentService;
        

        public DepartmentsController(DepartmentService departmentService)
        {
            _departmentService = departmentService;
            
        }


        // GET: Departments
        public async Task<IActionResult> Index()
        {
            var list = await _departmentService.FindAllDepAsync();
            return View(list);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var obj = await _departmentService.FindByIdDepAsync(id);
            if(obj == null)
            {
                return NotFound();
            }
            return View(obj);   
        }



       
        // GET: Departments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Departments/Create
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Department department)
        {
            if (ModelState.IsValid)
            {
                 await  _departmentService.InsertAsync(department);
                
                return  RedirectToAction(nameof(Index));
            }
            return  View(department);
        }

        //Delete department GET
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var department = await _departmentService.FindByIdDepAsync(id.Value);
            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }


        //Delete Post
        [HttpPost , ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _departmentService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));

        }




        //// GET: Departments/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var department = await _context.Department.FindAsync(id);
        //    if (department == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(department);
        //}

        //// POST: Departments/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Department department)
        //{
        //    if (id != department.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(department);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!DepartmentExists(department.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(department);
        //}


       

        //private bool DepartmentExists(int id)
        //{
        //    return _context.Department.Any(e => e.Id == id);
        //}
    }
}
