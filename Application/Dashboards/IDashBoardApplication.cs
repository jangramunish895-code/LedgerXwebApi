using Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dashboards
{
    public interface IDashBoardApplication
    {
        public  Task<DashboardDto> GetDashboard();
    }
}
