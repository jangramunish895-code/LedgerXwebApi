using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class ShopSetting: BaseEntity
    {
        public int Id { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }
        public string ShopName { get; set; }
        public string OwnerName { get; set; }
        public string PhoneNumber { get; set; }
        public string? GstNumber { get; set; }
    }
}
