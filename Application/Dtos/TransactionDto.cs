using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dtos
{
    public class TransactionDto
    {
       
            public int Id { get; set; }
            public int CustomerId { get; set; }
            public TransactionType TransactionType { get; set; }
            public int Amount { get; set; }
            public string? Description { get; set; }
        
    }
}
