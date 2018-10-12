using System;
using AuthServer.Data.Models;
using AuthServer.Exceptions;
using AuthServer.Services;
using Microsoft.AspNetCore.Mvc;

namespace AuthServer.Controllers
{
    [Route("auth")]
    public class AuthController :Controller
    {
        private readonly IUserService _service;
        private readonly ITokenGenerator _tokengenerator;
        public AuthController(IUserService service, ITokenGenerator tokenGenerator)
        {
            _service = service;
            _tokengenerator = tokenGenerator;
        }

        //this method will be called by the client app with the user object for getting the JWT token
        [HttpPost]
        [Route("register")]
        public IActionResult Register([FromBody]User user)
        {
            try
            {
                if (_service.IsUserExists(user.UserId) == true)
                {
                    return StatusCode(409, "A user already exists with this id");
                }
                else
                {
                    _service.RegisterUser(user);
                    return StatusCode(201,"You are successfully registered!");
                }
            }
            catch (Exception)
            {
                return StatusCode(500,"There is some server error");
            }
        }

        //this method will be called by the client app with the user object for getting the JWT token
        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody]User user)
        {
            try
            {
                string userId = user.UserId;
                string password = user.Password;

                User _user= _service.Login(userId, password);

                //calling the function for the JWT token for respecting user
                string value = _tokengenerator.GetJWTToken(user.UserId);
                //returning the token to the consumer app
                return Ok(value);
            }
            catch (UserNotFoundException unf)
            {
                return NotFound(unf.Message);
            }
            catch
            {
                return StatusCode(500,"Some server error");
            }
        }
    }
}
