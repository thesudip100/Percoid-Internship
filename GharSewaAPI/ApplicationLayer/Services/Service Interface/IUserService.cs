using DomainLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Services.Service_Interface
{
    public interface IUserService
    {
        Task RegisterUserAsync(UserRegisterDTO user);
        Task<string> UserLoginAsync(LoginDTO user);
    }
}
