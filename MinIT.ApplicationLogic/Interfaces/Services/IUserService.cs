using MinIT.ApplicationLogic.Entities.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MinIT.ApplicationLogic.Interfaces.Services
{
    public interface IUserService
    {
        Task<UserEntity> RegisterUserAsync(UserEntity userEntity);

        UserEntity GetAllUsersAsync();
    }
}
