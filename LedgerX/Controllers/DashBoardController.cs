using Application.Dashboards;
using Application.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LedgerX.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashBoardController : ControllerBase
    {
        private readonly IDashBoardApplication _dashBoardApplication;

        public DashBoardController(IDashBoardApplication dashBoardApplication)
        {
            _dashBoardApplication = dashBoardApplication;
        }

        [HttpGet]
        public async Task<DashboardDto> Get()
        {
             return await _dashBoardApplication.GetDashboard();
            
        }
    }
}
