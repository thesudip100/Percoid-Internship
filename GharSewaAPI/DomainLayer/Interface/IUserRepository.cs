using DomainLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Interface
{
    public interface IUserRepository
    {
        Task<string> CreateUserAsync(UserRegisterDTO user);
        Task<string> LoginUserAsync(LoginDTO user);
        Task<string> EditUserProfileAsync(EditUserDTO user, int id);
        Task<EditUserDTO> GetUserbyIdAsync(int id);
        Task<string> DeleteUserAsync(int id);
        Task<string> ChangePasswordAsync(ChangePasswordDTO user, int id);
        /*Task<string> OTPGenerationAsync(OTPGenerationDTO user);*/
    }
}
