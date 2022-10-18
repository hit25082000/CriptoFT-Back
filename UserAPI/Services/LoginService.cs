using FluentResults;
using Microsoft.AspNetCore.Identity;
using UserAPI.Data.Requests;
using UserAPI.Models;

namespace UserAPI.Services
{
    public class LoginService
    {
        private SignInManager<IdentityUser<int>> _signInManager;
        private TokenService _tokenService;

        public LoginService(SignInManager<IdentityUser<int>> signInManager, TokenService tokenService)
        {
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        public Result UserLogin(LoginRequest request)
        {
            var identityResult = _signInManager.PasswordSignInAsync(request.Username, request.Password,false,false);

            if (identityResult.Result.Succeeded)
            {
                var identityUser = _signInManager.UserManager.Users.FirstOrDefault(user => user.NormalizedUserName == request.Username.ToUpper());

                Token token = _tokenService.CreateToken(identityUser);
                return Result.Ok().WithSuccess(token.Value);
            }
            return Result.Fail("Login falhou");
        }

        public Result RequestPasswordReset(RequestPasswordResetRequest request)
        {
            IdentityUser<int> identityUser = GetUserFromEmail(request.Email);

            if (identityUser != null)
            {
                string recoverCode = _signInManager.UserManager.GeneratePasswordResetTokenAsync(identityUser).Result;
                return Result.Ok().WithSuccess(recoverCode);
            }

            return Result.Fail("Falha ao solicitar redefinição de senha");
        }

        public Result PasswordReset(ResetPasswordRequest request)
        {
            IdentityUser<int> identityUser = GetUserFromEmail(request.Email);

            IdentityResult identityResult = _signInManager.UserManager.ResetPasswordAsync(identityUser, request.Token, request.Password).Result;

            if (identityResult.Succeeded) return Result.Ok().WithSuccess("Senha redefinida com sucesso");
            return Result.Fail("Houve erro na redefinição");
        }
        private IdentityUser<int> GetUserFromEmail(string email)
        {
            return _signInManager.UserManager.Users.FirstOrDefault(u => u.NormalizedEmail == email.ToUpper());
        }
    }
}
