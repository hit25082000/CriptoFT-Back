using FluentResults;
using Microsoft.AspNetCore.Mvc;
using UserAPI.Data.Requests;
using UserAPI.Services;

namespace UserAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id}")]
        public async Task<bool> VerifyUser(string id)
        {
            Result result = _userService.VerifyUser(id);
            if (result.IsFailed) return false;
            return true;
        }       
    }
}
