using Application.Dtos;
using Domain;
using Infrastructure.Repositories.ShopSettings;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.ShopSettings
{
    public class ShopSettingsApplication: IShopSettingsApplication
    {
        private readonly IShopSettingsRepository _shopSettingsRepository;

        public ShopSettingsApplication(IShopSettingsRepository shopSettingsRepository)
        {
            _shopSettingsRepository = shopSettingsRepository;
        }

        public async Task Add(CreateUpdateShopSettingsdto input)
        {
          ShopSetting shopSetting = new ShopSetting
            {
                UserId = input.UserId,
                ShopName = input.ShopName,
                OwnerName = input.OwnerName,
                PhoneNumber = input.PhoneNumber,
                GstNumber = input.GstNumber
            };
            await _shopSettingsRepository.Add(shopSetting);

        }

        public async Task Delete(int id)
        {
        await _shopSettingsRepository.Delete(id);

        }

        public async Task<List<ShopSettingsDto>> GetAll()
        {
           var shopSettings = await _shopSettingsRepository.GetAll();
            var dto = shopSettings.Select(s => new ShopSettingsDto
            {
                Id = s.Id,
                UserId = s.UserId,
                ShopName = s.ShopName,
                OwnerName = s.OwnerName,
                PhoneNumber = s.PhoneNumber,
                GstNumber = s.GstNumber
            }).ToList();
            return dto;
        }

        public async Task<ShopSettingsDto> GetById(int id)
        {
          var shopsetting=await _shopSettingsRepository.GetById(id);
         var dto = new ShopSettingsDto
            {
                Id = shopsetting.Id,
                UserId = shopsetting.UserId,
                ShopName = shopsetting.ShopName,
                OwnerName = shopsetting.OwnerName,
                PhoneNumber = shopsetting.PhoneNumber,
                GstNumber = shopsetting.GstNumber
            };
            return dto;
        }

        public  async Task Update(int id, CreateUpdateShopSettingsdto input)
        {
          var shopSetting = await _shopSettingsRepository.GetById(id);
            if (shopSetting != null)
            {
                shopSetting.UserId = input.UserId;
                shopSetting.ShopName = input.ShopName;
                shopSetting.OwnerName = input.OwnerName;
                shopSetting.PhoneNumber = input.PhoneNumber;
                shopSetting.GstNumber = input.GstNumber;
                await _shopSettingsRepository.Update(shopSetting);
            }
        }
    }
}
