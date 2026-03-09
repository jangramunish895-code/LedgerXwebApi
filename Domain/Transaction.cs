using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int TransactionType { get; set; }
        public int Amount { get; set; }
        
    }
}
