using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Data;
using SalesWebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Services
{
    public class DepartmentService
    {
        private readonly SalesWebMvcContext _context;

        public DepartmentService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public async Task<List<Department>> FindAllDep()
        {
            return await _context.Department.OrderBy(x => x.Name).ToListAsync();
        }

        public async Task<Department> Insert(Department department)
        {
             await _context.AddAsync(department);
              _context.SaveChanges();
            return department;
        }
        
    }
}
