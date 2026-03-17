using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.ShopSettings
{
    internal class ShopSettingsRepository : IShopSettingsRepository
    {
        private readonly DataContext _context;
        public ShopSettingsRepository(DataContext context) {
            _context = context;
        }

        public  async Task Add(ShopSetting input)
        {
          _context.ShopSettings.Add(input);
       await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var shopSetting =  _context.ShopSettings.Find(id);
            if (shopSetting != null)
            {
                _context.ShopSettings.Remove(shopSetting);
                await _context.SaveChangesAsync();
            }

        }

        public  async Task<List<ShopSetting>> GetAll()
        {
            return await _context.ShopSettings.ToListAsync();
        }

        public async Task<ShopSetting> GetById(int id)
        {
            return await _context.ShopSettings.FindAsync(id);
        }

      

        public  async Task Update(ShopSetting shopSetting)
        {
            _context.ShopSettings.Update(shopSetting);
            await _context.SaveChangesAsync();
        }
    }
}
