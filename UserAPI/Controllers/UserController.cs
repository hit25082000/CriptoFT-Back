using FluentResults;
using Microsoft.AspNetCore.Mvc;
using UserAPI.Data.Requests;
using UserAPI.Models;
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
        public bool VerifyUser(string id)
        {
            Result result = _userService.VerifyUser(id);
            if (result.IsFailed) return false;
            return true;
        }

        [HttpGet("{id}")]
        public JsonResult GetUserProfile(int id)
        {
            Profile profile = _userService.GetUserProfile(id);
            return new JsonResult(profile);
        }

        [HttpPost]
        public bool AddProfile([FromQuery] Profile profile,int userId)
        {
            Result result = _userService.AddProfile(profile,userId);
            if (result.IsFailed) return false;
            return true;
        }

        [HttpPost]
        public bool EditProfile([FromQuery] Profile profile)
        {
            Result result = _userService.EditProfile(profile);
            if (result.IsFailed) return false;
            return true;
        }
    }
}
