using FluentResults;
using Microsoft.AspNetCore.Mvc;
using UserAPI.Data.Requests;
using UserAPI.Services;

namespace UserAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private LoginService _loginService;

        public LoginController(LoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        public IActionResult UserLogin(LoginRequest request)
        {
            Result result = _loginService.UserLogin(request);
            if (result.IsFailed) return Unauthorized(result.Errors);

            return Ok(result.Successes);
        }

        [HttpPost("/solicita-reset-senha")]
        public IActionResult RequestPasswordReset(RequestPasswordResetRequest request)
        {
            Result result = _loginService.RequestPasswordReset(request);
            if (result.IsFailed) return Unauthorized(result.Errors);
            return Ok(result.Successes);
        }

        [HttpPost("/redefinir-senha")]
        public IActionResult PasswordReset(ResetPasswordRequest request)
        {
            Result result = _loginService.PasswordReset(request);
            if (result.IsFailed) return Unauthorized(result.Errors);
            return Ok(result.Successes);
        }
    }
}
