﻿using FluentResults;
using Microsoft.AspNetCore.Mvc;
using UserAPI.Data.Dtos;
using UserAPI.Data.Requests;
using UserAPI.Services;

namespace UserApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private RegisterService _registerService;

        public RegisterController(RegisterService registerService)
        {
            _registerService = registerService;
        }

        [HttpPost]
        public IActionResult RegisterUser([FromBody] CreateUserDto createDto)
        {
            Result result = _registerService.RegisterUser(createDto);
            if (result.IsFailed) return StatusCode(500,result);
            return Ok(result.Successes);
        }      
        
        [HttpGet("/ativa")]
        public IActionResult UserAcountActivate([FromQuery] AcountActivationRequest request)
        {
            Result result = _registerService.UserAcountActivate(request);
            if (result.IsFailed) return StatusCode(500);
            return Ok(result.Successes);
        }
    }
}