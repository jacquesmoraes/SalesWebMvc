using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Controllers
{
    public class SalesRecordsController : Controller
    {
        private readonly SalesRecordService _salesRecordService;

        public SalesRecordsController(SalesRecordService salesRecordService)
        {
            _salesRecordService = salesRecordService;
        }

        public async Task<IActionResult> Index()
        {
            var Sales = await _salesRecordService.FindAllSales();
            return View(Sales);
        }
        public IActionResult Search()
        {
            return View();
        }
        public async Task<IActionResult> SimpleSearch(DateTime? min, DateTime? max)
        {
            if (!min.HasValue)
            {
                min = new DateTime(DateTime.Now.Year, 1, 1);
            }
            if (!max.HasValue)
            {
                max = DateTime.Now;
            }
            ViewData["min"] = min.Value.ToString("yyyy-MM-dd");
            ViewData["max"] = max.Value.ToString("yyyy-MM-dd");
            var result = await _salesRecordService.FindByDateAsync(min, max);
            return View(result);
        }

        public IActionResult GroupingSearch()
        {
            return View();
        }
    }
}
