using MinIT.ApplicationLogic.Entities.Users;
using MinIT.ApplicationLogic.Interfaces.Services;
using MinIT.Domain;
using MinIT.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinIT.ApplicationLogic.Services
{
    public class UserService : IUserService
    {
        private readonly IBaseRepository<User> _userRepository;

        public UserService(IBaseRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public UserEntity GetAllUsersAsync()
        {
            var users = _userRepository.All();

            return new UserEntity
            {
                Users = users.Select(u => new UserEntity
                {
                    Id = u.Id,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Email = u.Email
                })
            };
        }

        public async Task<UserEntity> RegisterUserAsync(UserEntity userEntity)
        {
            var user = new User
            {
                FirstName = userEntity.FirstName,
                LastName = userEntity.LastName,
                Email = userEntity.Email
            };

            _userRepository.Add(user);
            await _userRepository.SaveAsync();

            return new UserEntity
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email
            };
        }
    }
}
