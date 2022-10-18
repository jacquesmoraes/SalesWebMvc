using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Data;
using SalesWebMvc.Models;
using SalesWebMvc.Models.ViewModels;
using SalesWebMvc.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SalesWebMvc.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _sellerService;
        private readonly DepartmentService _departmentService;

        public SellersController(SellerService sellerService, DepartmentService departmentService)
        {
            _sellerService = sellerService;
            _departmentService = departmentService;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _sellerService.FindAll();
            return View( list);
        }

        //CreateGet//
        public async Task<IActionResult> Create()
        {
            var department = await _departmentService.FindAllDep();
            var ViewModel = new SellerFormViewModel { Departments = department };
            return View(ViewModel);
        }

        //CreatePost//
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name, Email,BirthDate,Salary, Seller, DepartmentId")] Seller seller)
        {
              await  _sellerService.InsertSeller(seller);
            return  RedirectToAction(nameof(Index));

        }

        //Delete Get//
       public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var obj = _sellerService.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);

        }
         
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int id)
        {
             _sellerService.Remove(id);
            return RedirectToAction(nameof(Index));

        }
    }
}
