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
                Email = input.Email,
                OwnerName = input.OwnerName,
                PhoneNumber = input.PhoneNumber,
                GstNumber = input.GstNumber,
              



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
                Email = s.Email,
                OwnerName = s.OwnerName,
                PhoneNumber = s.PhoneNumber,
                GstNumber = s.GstNumber,
                User =s.User== null ? null : new UserDto
                {
                    Id = s.User.Id,
                    FirstName = s.User.FirstName,
                    LastName = s.User.LastName,
                    City = s.User.City,
                    Country = s.User.Country,
                    Role = s.User.Role,
                    Email = s.User.Email,
                    State = s.User.State,
                    Address1 = s.User.Address1,
                    Address2 = s.User.Address2,
                   
                    PhoneNumber = s.User.PhoneNumber

                },
                CreatedDate = DateTime.UtcNow,
                IsDeleted = false,
                IsActive = false,
                UpdatedDate = DateTime.UtcNow,
            }).ToList();
            return dto;
        }

        public async Task<ShopSettingsDto> GetById(int id)
        {
            var shopsetting = await _shopSettingsRepository.GetById(id);
            var dto = new ShopSettingsDto
            {
                Id = shopsetting.Id,
                UserId = shopsetting.UserId,
                ShopName = shopsetting.ShopName,
                Email = shopsetting.Email,
                OwnerName = shopsetting.OwnerName,
                PhoneNumber = shopsetting.PhoneNumber,
                GstNumber = shopsetting.GstNumber,
                User=new UserDto
                {
                    Id = shopsetting.User.Id,
                    FirstName = shopsetting.User.FirstName,
                    LastName = shopsetting.User.LastName,
                    City = shopsetting.User.City,
                    Country = shopsetting.User.Country,
                    Role = shopsetting.User.Role,
                    Email = shopsetting.User.Email,
                    State = shopsetting.User.State,
                    Address1 = shopsetting.User.Address1,
                    Address2 = shopsetting.User.Address2,
                    PhoneNumber = shopsetting.User.PhoneNumber
                },
            };
            return dto;
        }

        public async Task Update(int id, CreateUpdateShopSettingsdto input)
        {
            var shopSetting = await _shopSettingsRepository.GetById(id);
            if (shopSetting != null)
            {
                shopSetting.UserId = input.UserId;
                shopSetting.ShopName = input.ShopName;
                shopSetting.Email = input.Email;
                shopSetting.OwnerName = input.OwnerName;
                shopSetting.PhoneNumber = input.PhoneNumber;
                shopSetting.GstNumber = input.GstNumber;
                await _shopSettingsRepository.Update(shopSetting);
            }
        }
    }
}
