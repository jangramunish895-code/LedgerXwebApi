

using Domain;

namespace Infrastructure.Repositories.ShopSettings
{
    public interface IShopSettingsRepository
    {
        public Task Add(ShopSetting input);
        public Task<ShopSetting> GetById(int id);
       
        public Task<List<ShopSetting>> GetAll();
        public Task Update(ShopSetting shopSetting);
        public Task Delete(int id);
    }
}
