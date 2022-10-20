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

        public async Task<List<Department>> FindAllDepAsync()
        {
            return await _context.Department.OrderBy(x => x.Name).ToListAsync();
        }
        public async Task<Department> FindByIdDepAsync(int? id)
        {
            return await _context.Department.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Department> InsertAsync(Department department)
        {
             await _context.AddAsync(department);
              _context.SaveChanges();
            return department;
        }

        public async Task  DeleteAsync(int id)
        {
            var obj = await _context.Department.FindAsync(id);
            _context.Remove(obj);
            _context.SaveChanges();

        }
        
    }
}
