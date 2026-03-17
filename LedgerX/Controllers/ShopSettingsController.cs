using Application.Dtos;
using Application.ShopSettings;
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
        private readonly IShopSettingsApplication _shopSettingsApplication;

        public ShopSettingsController(IShopSettingsApplication shopSettingsApplication)
        {
            _shopSettingsApplication = shopSettingsApplication;
        }

        [HttpGet]
        public async Task<ActionResult<List<ShopSettingsDto>>> GetShopSettings()
        {
            try
            {
                var shopSettings = await _shopSettingsApplication.GetAll();
                return Ok(shopSettings);
            }
            catch (Exception ex)
            {
                return StatusCode(400, "An error occurred ");
            }

        }

        [HttpPost]
        public async Task<ActionResult> AddOrUpdateShopSettings(CreateUpdateShopSettingsdto shopSettingsDto)
        {
            try
            {
                await _shopSettingsApplication.Add(shopSettingsDto);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(400, "An error occurred ");
            }

        }

        [HttpDelete]
        public async Task<ActionResult> DeleteShopSettings(int id)
        {
            try
            {
               await _shopSettingsApplication.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(400, "An error occurred ");
            }
        }


    }
}