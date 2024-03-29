﻿using IsatiIntegration.API.Entities;
using IsatiIntegration.API.Models.Users;
using IsatiIntegration.API.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IsatiIntegration.API.Controllers.v1
{
    [Route("v1/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        /// <summary>
        /// Login a user to the API
        /// </summary>
        /// <param name="loginModel"></param>
        /// <response code="400">The user doesn't exist or the password doesn't match</response>
        /// <response code="200">Return the logged user with valid token</response>
        /// <returns></returns>
        [HttpPost("login")]
        public async Task<ActionResult<User>> Login([FromBody] LoginModel loginModel)
        {
            try
            {
                User user = await _authenticationService.LoginAsync(loginModel.Email, loginModel.Password);

                if (user == null)
                {
                    return BadRequest("The username or password is incorrect");
                }

                return Ok(user);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Register a new user to the database
        /// </summary>
        /// <param name="registerModel"></param>
        /// <response code="400">There was one or more errors during registration validation</response>
        /// <response code="200">Return the newly registrated user's id</response>
        /// <returns></returns>
        [HttpPost("register")]
        public async Task<ActionResult<string>> Register([FromBody] RegisterModel registerModel)
        {
            string userId;

            try
            {
                userId = await _authenticationService.RegisterAsync(registerModel);
            }
            catch (Exception e)
            {
                return BadRequest($"Error during user registration: {e.Message}");
            }

            return Ok(userId);
        }
    }
}
