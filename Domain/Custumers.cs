using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Custumers: BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Notes { get; set; }
        public int Balance { get; set; }
      
        public string ProfilePicURL { get; set; }
        //public List <Transaction> Transactions { get; set; }
    }
}
