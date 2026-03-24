using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Common
{
    public class BadRequestException :Exception
    {
        public BadRequestException(string message) : base(message)
        {
        }
        public BadRequestException() : base()
        {
        }
    }
}
