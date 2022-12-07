using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using System.Web;
using UserAPI.Data.Dtos;
using UserAPI.Data.Requests;
using UserAPI.Models;

namespace UserAPI.Services
{
    public class UserService
    {
        private UserManager<IdentityUser<int>> _userManager;

        public UserService(UserManager<IdentityUser<int>> userManager)
        {
            _userManager = userManager;
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
