using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using UserAPI.Data;
using UserAPI.Models;

namespace UserAPI.Services
{
    public class UserService
    {
        private UserManager<IdentityUser<int>> _userManager;
        private UserDbContext _context;
        private IMapper _map;

        public UserService(UserManager<IdentityUser<int>> userManager, UserDbContext context, IMapper map)
        {
            _userManager = userManager;
            _context = context;
            _map = map;
        }

        public Result VerifyUser(string verifyUserRequest)
        {
            var userExist = _userManager.FindByNameAsync(verifyUserRequest);

            if (userExist == null)
            {
                return Result.Ok();
            }

            return Result.Fail("Falha usuario ja existe");
        }     
    }
}
