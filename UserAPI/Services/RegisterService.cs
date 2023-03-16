using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using System.Web;
using UserAPI.Data.Dtos;
using UserAPI.Data.Requests;
using UserAPI.Models;

namespace UserAPI.Services
{
    public class RegisterService
    {
        private IMapper _mapper;
        private UserManager<IdentityUser<int>> _userManager;
        private EmailService _emailService;

        public RegisterService(IMapper mapper, UserManager<IdentityUser<int>> userManager, EmailService emailService)
        {
            _mapper = mapper;
            _userManager = userManager;
            _emailService = emailService;
        }

        public Result RegisterUser(CreateUserDto createDto)
        {
            User user = _mapper.Map<User>(createDto);
            IdentityUser<int> userIdentity = _mapper.Map<IdentityUser<int>>(user);
            Task<IdentityResult> resultIdentity = _userManager
                .CreateAsync(userIdentity, createDto.Password);
            if (resultIdentity.Result.Succeeded) 
            {
                var code = _userManager.GenerateEmailConfirmationTokenAsync(userIdentity).Result;

                var encodedCode = HttpUtility.UrlEncode(code);

                _emailService.SendEmail(new[] {userIdentity.Email }, "Link de ativação", userIdentity.Id, encodedCode);
                return Result.Ok().WithSuccess(code);
            }
            return Result.Fail(resultIdentity.Result.ToString());
        }

        public Result UserAcountActivate(AcountActivationRequest request)
        {
            var identityUser = _userManager
                .Users
                .FirstOrDefault(u => u.Id == request.UserId);
            var identityResult = _userManager
                .ConfirmEmailAsync(identityUser, request.ActivationCode).Result;
            if (identityResult.Succeeded)
            {
                return Result.Ok();
            }
            return Result.Fail("Falha ao ativar conta de usuario");
        }
    }
}
