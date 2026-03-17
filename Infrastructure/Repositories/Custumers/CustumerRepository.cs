using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories.Custumers
{
    public class CustumerRepository : ICustumerRepository
    {
        private readonly DataContext _context;

        public CustumerRepository(DataContext context) 
        { 
            _context = context;
        }

        public async Task Add(Custumer input)
        {
            _context.Custumers.Add(input);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var custumer = await _context.Custumers.FindAsync(id);
            if (custumer != null)
            {
                _context.Custumers.Remove(custumer);
                await _context.SaveChangesAsync();
            }
        }

        public  async Task<List<Custumer>> GetAll()
        {
          return await _context.Custumers.ToListAsync();
        }
            
        public  async Task<Custumer> GetById(int id)
        {
           return await _context.Custumers.FindAsync(id);
        }

        public  async Task Update(Custumer custumer)
        {
            _context.Custumers.Update(custumer);
            await _context.SaveChangesAsync();
        }
    }
}
