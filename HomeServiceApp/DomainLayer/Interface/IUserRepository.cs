using DomainLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Interface
{
    public interface IUserRepository<T> where T : class
    {
        Task<string> CreateUser(UserRegisterDTO user);
    }
}
