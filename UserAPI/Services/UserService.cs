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

        public Models.Profile GetUserProfile(int userId)
        {
            Models.Profile profile = _context.UserProfile.FirstOrDefault(x => x.User.Id == userId);            

            return profile;
        }

        public Result AddProfile(Models.Profile profile,int userId)
        {
            var user = _context.Users.Find(userId.ToString());

            if(user == null)
            {
                return Result.Fail("Falha usuario não encontrado");
            }

            if(GetUserProfile(user.Id) != null)
            {
              return Result.Fail("Falha usuario ja tem perfil");
            }

            profile.User = _map.Map<User>(user);

            _context.UserProfile.Add(profile);

            _context.SaveChanges();

            return Result.Ok();
        }

        public Result EditProfile(Models.Profile profile)
        {
            _context.Update(profile);

            _context.SaveChanges();           

            return Result.Ok();
        }
    }
}
