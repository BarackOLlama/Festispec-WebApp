using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Festispec_WebApp.DataTransferObjects;
using Festispec_WebApp.Helpers;
using Festispec_WebApp.Models;
using Festispec_WebApp.Services;

namespace Festispec_WebApp.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;
 
        public UsersController(IAccountService accountService, IMapper mapper, IOptions<AppSettings> appSettings)
        {
            _accountService = accountService;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }
 
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]UserDto userDto)
        {
            var user = _accountService.Authenticate(userDto.Username, userDto.Password);
            
            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });
 
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] 
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
 
            // return basic user info (without password) and token to store client side
            return Ok(new {
                Id = user.Id,
                Username = user.Username,
                Token = tokenString
            });
        }
 
        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register([FromBody]UserDto userDto)
        {
            // map dto to entity
            var user = _mapper.Map<Accounts>(userDto);
 
            try
            {
                // save 
                _accountService.Create(user, userDto.Password);
                return Ok();
            } 
            catch(AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }
        
        /**
         * Per MS defined clams Name is in this context USER ID!
         */
        [HttpGet("VerifyToken")]
        public IActionResult VerifyToken()
        {
            var user = User.Identity;
            if (user.IsAuthenticated)
            {
                return Ok(user.Name);
            }

            return Forbid();
        }
        [AllowAnonymous]

        [HttpGet]
        public IActionResult GetAll()
        {
            var users =  _accountService.GetAll();
//            var userDtos = _mapper.Map<IList<UserDto>>(users);
            return Ok(users);
        }
        [AllowAnonymous]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user =  _accountService.GetById(id);
//            var userDto = _mapper.Map<UserDto>(user);
            return Ok(user);
        }
 
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]UserDto userDto)
        {
            // map dto to entity and set id
            var user = _mapper.Map<Accounts>(userDto);
            user.Id = id;
 
            try
            {
                // save 
                _accountService.Update(user, userDto.Password);
                return Ok();
            } 
            catch(AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }
 
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _accountService.Delete(id);
            return Ok();
        }
    }
}