using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using GitHub.Domain.Interfaces.Service;

namespace GitHub.Service.Services
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string message)
        {
            return Task.CompletedTask;
        }
    }
}
