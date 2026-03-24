using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Email
{
    public interface IEmailService
    {
        Task SendEmail(string email, string subject, string message);
    }
}
