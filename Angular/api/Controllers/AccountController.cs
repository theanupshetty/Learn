using System.Security.Cryptography;
using System.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Angular.Data;
using Angular.Models;
using Microsoft.EntityFrameworkCore;
using Angular.implementations;
using Angular.interfaces;

namespace Angular.api.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly IUsers<AppUser> _users;
        private readonly ITokenService _tokenService;

        public AccountController(IUsers<AppUser> users, ITokenService tokenservice)
        {
            _users = users;
            _tokenService = tokenservice;
        }
        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(Register registerDto)
        {
            if (await _users.UserExists(registerDto.Username))
                return BadRequest("username is taken");
            using var hmac = new HMACSHA512();
            var user = new AppUser
            {
                UserName = registerDto.Username.ToLower(),
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
                PasswordSalt = hmac.Key
            };
            await _users.CreateUser(user);
            return new UserDto
            {
                Username = user.UserName,
                Token = _tokenService.CreateToken(user)
            };


        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(Login loginDto)
        {
            var user = await _users.GetUserByUsernameAsync(loginDto.UserName);
            if (user == null) return Unauthorized("Invalid username");
            using var hamc = new HMACSHA512(user.PasswordSalt);
            var computedHash = hamc.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));
            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash[i]) return Unauthorized("Invalid password");

            }
            return new UserDto
            {
                Username = user.UserName,
                Token = _tokenService.CreateToken(user)
            };
        }
    }
}