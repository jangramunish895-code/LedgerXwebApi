using Application.Dtos;
using Domain;
using Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LedgerX.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopSettingsController : ControllerBase
    {
        private readonly DataContext _context;

        public ShopSettingsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<ShopSettingsDto>> GetShopSettings()
        {
            try
            {
                var shopSettings = await _context.ShopSettings.FirstOrDefaultAsync();
                if (shopSettings == null)
                {
                    return NotFound("Shop settings not found.");
                }
                var shopSettingsDto = new ShopSettingsDto
                {
                    Id = shopSettings.Id,
                    UserId = shopSettings.UserId,
                    ShopName = shopSettings.ShopName,
                    OwnerName = shopSettings.OwnerName,
                    PhoneNumber = shopSettings.PhoneNumber,
                    GstNumber = shopSettings.GstNumber
                };
                return Ok(shopSettingsDto);

            }
            catch (Exception ex)
            {
                // Log the exception (not implemented here)
                return StatusCode(400, "An error occurred ");
            }


        }

        [HttpPost]
        public async Task<ActionResult<CreateUpdateShopSettingsdto>> AddOrUpdateShopSettings(CreateUpdateShopSettingsdto shopSettingsDto)
        {
            try
            {
                var existingSettings = await _context.ShopSettings.FirstOrDefaultAsync();
                if (existingSettings != null)
                {
                    // Update existing settings
                    existingSettings.UserId = shopSettingsDto.UserId;
                    existingSettings.ShopName = shopSettingsDto.ShopName;
                    existingSettings.OwnerName = shopSettingsDto.OwnerName;
                    existingSettings.PhoneNumber = shopSettingsDto.PhoneNumber;
                    existingSettings.GstNumber = shopSettingsDto.GstNumber;
                    _context.ShopSettings.Update(existingSettings);
                    await _context.SaveChangesAsync();
                    return Ok(new ShopSettingsDto
                    {
                        Id = existingSettings.Id,
                        UserId = existingSettings.UserId,
                        ShopName = existingSettings.ShopName,
                        OwnerName = existingSettings.OwnerName,
                        PhoneNumber = existingSettings.PhoneNumber,
                        GstNumber = existingSettings.GstNumber
                    });
                }
                else
                {
                    // Create new settings
                    var newShopSettings = new ShopSetting
                    {
                        UserId = shopSettingsDto.UserId,
                        ShopName = shopSettingsDto.ShopName,
                        OwnerName = shopSettingsDto.OwnerName,
                        PhoneNumber = shopSettingsDto.PhoneNumber,
                        GstNumber = shopSettingsDto.GstNumber
                    };
                    _context.ShopSettings.Add(newShopSettings);
                    await _context.SaveChangesAsync();
                    return Ok(new ShopSettingsDto
                    {
                        Id = newShopSettings.Id,
                        UserId = newShopSettings.UserId,
                        ShopName = newShopSettings.ShopName,
                        OwnerName = newShopSettings.OwnerName,
                        PhoneNumber = newShopSettings.PhoneNumber,
                        GstNumber = newShopSettings.GstNumber
                    });
                }
            }
            catch (Exception ex)
            {

                return StatusCode(400, "An error occurred ");
            }
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteShopSettings()
        {
            try
            {
                var shopSettings = await _context.ShopSettings.FirstOrDefaultAsync();
                if (shopSettings == null)
                {
                    return NotFound("Shop settings not found.");
                }
                _context.ShopSettings.Remove(shopSettings);
                await _context.SaveChangesAsync();
                return Ok("Shop settings deleted successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(400, "An error occurred ");
            }
        }


    }
}