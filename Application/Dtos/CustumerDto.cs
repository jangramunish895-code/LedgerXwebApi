using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dtos
{
    public class CustumerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Notes { get; set; }
        public int Balance { get; set; }
        public string ProfilePicURL { get; set; }
    }
}
