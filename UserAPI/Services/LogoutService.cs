using FluentResults;
using Microsoft.AspNetCore.Identity;

namespace UserAPI.Services
{
    public class LogoutService
    {
        private SignInManager<IdentityUser<int>> _signInManager;

        public LogoutService(SignInManager<IdentityUser<int>> signInManager)
        {
            _signInManager = signInManager;
        }

        public Result UserLogout()
        {
            var identityResult = _signInManager.SignOutAsync();
            if (identityResult.IsCompletedSuccessfully) return Result.Ok();
            return Result.Fail("Logout falhou");
        }
    }
}
