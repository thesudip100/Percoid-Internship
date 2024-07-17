using DomainLayer.DTO;
using DomainLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Services.Service_Interface
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }
        public async Task RegisterUserAsync(UserRegisterDTO user)
        {
              await _repository.CreateUserAsync(user);
        }

        public Task<string> UserLoginAsync(LoginDTO user)
        {
            return _repository.LoginUserAsync(user);
        }
    }
}
