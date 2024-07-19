using ApplicationLayer.Services.Service_Interface;
using DomainLayer.DTO;
using DomainLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Services.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public Task<string> ChangePasswordAsync(ChangePasswordDTO user, int id)
        {
            return _repository.ChangePasswordAsync(user, id);
        }

        public Task<string> DeleteUserAsync(int id)
        {
            return _repository.DeleteUserAsync(id);
        }

        public Task<string> EditUserProfileAsync(EditUserDTO user, int id)
        {
            return _repository.EditUserProfileAsync(user, id);
        }

        public Task<EditUserDTO> GetUserbyIdAsync(int id)
        {
            return _repository.GetUserbyIdAsync(id);
        }

/*        public Task<string> OTPGenerationAsync(OTPGenerationDTO user)
        {
            return _repository.OTPGenerationAsync(user);
        }*/

        public async Task<string> RegisterUserAsync(UserRegisterDTO user)
        {
            return await _repository.CreateUserAsync(user);
        }

        public Task<string> UserLoginAsync(LoginDTO user)
        {
            return _repository.LoginUserAsync(user);
        }
    }
}
