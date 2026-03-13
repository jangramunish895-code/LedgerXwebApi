using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dtos
{
    public class CreateUpdateUserDto
    {
      
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string PhoneNumber { get; set; }
            public string Address1 { get; set; }
        public string Address2 { get; set; }
            public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
            public string PinCode { get; set; }
            public string Password { get; set; }
        
    }
}
