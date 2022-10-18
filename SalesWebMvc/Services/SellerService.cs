using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Data;
using SalesWebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Services
{
    public class SellerService { 
        private readonly SalesWebMvcContext _context;

        public SellerService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public async Task<List<Seller>> FindAll()
        {
            return await _context.Seller.ToListAsync();
        }

        public async Task<Seller> InsertSeller(Seller seller)
        {
             
            await _context.AddAsync(seller);
            await _context.SaveChangesAsync();
            return seller;
        }
        public Seller FindById(int id)
        {
            return _context.Seller.FirstOrDefault(obj => obj.Id == id);
        }

       public void  Remove(int id)
        {
            var obj =  _context.Seller.Find(id);
            _context.Seller.Remove(obj);
             _context.SaveChanges();
            

        }
    }
}
