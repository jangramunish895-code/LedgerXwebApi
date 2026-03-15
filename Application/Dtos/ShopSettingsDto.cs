using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dtos
{
    public class ShopSettingsDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string ShopName { get; set; }
        public string OwnerName { get; set; }
        public string PhoneNumber { get; set; }
        public string? GstNumber { get; set; }
    }
}
