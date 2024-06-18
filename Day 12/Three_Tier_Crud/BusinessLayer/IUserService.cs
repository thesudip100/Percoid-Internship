using System.Collections.Generic;
using DataAccessLayer.Entities;

namespace MyMvcApp.Services
{
    public interface IUserService
    {
        IEnumerable<User> GetAllUsers();
        User? GetUserById(int id);
        void CreateUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int id);
    }
}


