using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MinIT.ApplicationLogic.Entities.Users;
using MinIT.ApplicationLogic.Interfaces.Services;
using MinIT.Common.ViewModels.User;

namespace MinIT.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            var users = _userService.GetAllUsersAsync();

            var result = new UserViewModel
            {
                Users = users.Users.Select(u => new UserViewModel
                {
                    Id = u.Id,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Email = u.Email
                })
            };
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser(RegisterUserViewModel registerUserViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = await _userService.RegisterUserAsync(new UserEntity
                {
                    FirstName = registerUserViewModel.FirstName,
                    LastName = registerUserViewModel.LastName,
                    Email = registerUserViewModel.LastName
                });
            }
            return Redirect("Index");
        }
    }
}