using GitHub.Domain.Models;
using GitHub.Domain.Commands.Sample;
using System;
using System.Collections.Generic;
using System.Text;
using GitHub.Domain.ViewModel;
using System.Threading.Tasks;

namespace GitHub.Domain.Interfaces.Service
{
    public interface IAccountService
    {
        Task<object> Login(LoginAccountCommand sample);
        Task<object> Register(RegisterAccountCommand sample);
    }
}
