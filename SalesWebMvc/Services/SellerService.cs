using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Data;
using SalesWebMvc.Models;
using SalesWebMvc.Services.Exceptions;
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

        public Seller FindById(int id)
        {
            return _context.Seller.Include(obj =>obj.Department).FirstOrDefault(obj => obj.Id == id);
        }

        public async Task<Seller> InsertSeller(Seller seller)
        {
             
            await _context.AddAsync(seller);
            await _context.SaveChangesAsync();
            return seller;
        }
       

       public void  Remove(int id)
        {
            var obj =  _context.Seller.Find(id);
            _context.Seller.Remove(obj);
             _context.SaveChanges();
      
        }

        public void Update(Seller seller)
        {
            if (!_context.Seller.Any(x => x.Id == seller.Id))
            {
                throw new NotFoundException("Id Not Found");
            }
            try
            {
                _context.Update(seller);
                _context.SaveChanges();
            }
            catch(DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }

    }
}
