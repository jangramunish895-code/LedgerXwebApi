using Application.Dtos;
using Domain.Enum;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dashboards
{
    public class DashBoardApplication: IDashBoardApplication
    {
        private readonly DataContext _context;
        public DashBoardApplication(DataContext context)
        {
            _context = context;
        }

        public  async Task<DashboardDto> GetDashboard()
        {
           var credits =  _context.Transactions.Where(t=>t.TransactionType == TransactionType.Credit).Sum(t=>t.Amount);
           var debits =  _context.Transactions.Where(t=>t.TransactionType == TransactionType.Debit).Sum(t=>t.Amount);
           var totalAmount = credits - debits;

           return new DashboardDto
           {
               Credits = credits,
               Debits = debits,
               TotalAmount = totalAmount
           };
        }
    }

}
