using Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.ShopSettings
{
    public interface IShopSettingsApplication
    {
        public Task Add(CreateUpdateShopSettingsdto input);

        public Task Update(int id, CreateUpdateShopSettingsdto input);
        public Task Delete(int id);
        public Task<List<ShopSettingsDto>> GetAll();
        public Task<ShopSettingsDto> GetById(int id);

    }
}
