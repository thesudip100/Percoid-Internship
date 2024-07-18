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
        Task<string> RegisterUserAsync(UserRegisterDTO user);
        Task<string> UserLoginAsync(LoginDTO user);
        Task<string> EditUserProfileAsync(EditUserDTO user, int id);
        Task<EditUserDTO> GetUserbyIdAsync(int id);
        Task<string> DeleteUserAsync(int id);
        Task<string> ChangePasswordAsync(ChangePasswordDTO user, int id);
        Task<string> OTPGenerationAsync(OTPGenerationDTO user);

    }
}
