using Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.Dtos
{
    public class CreateUpdateTransactionDto
    {
        [Required]
        public int CustomerId { get; set; }

        [Required]
        public TransactionType TransactionType { get; set; }

        [Required]
    
        public int Amount { get; set; }

        public string? Description { get; set; }
    }
}
