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
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using api.DTOs;

namespace Angular.api.Controllers
{
    [Authorize]
    public class UsersController : BaseApiController
    {
        private readonly IUsers<AppUser> _users;

        public UsersController(IUsers<AppUser> users)
        {
            _users = users;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            var users = await _users.GetMembersAsync();
            return Ok(users);
        }

        // [HttpGet("{id}")]
        // public async Task<ActionResult<IEnumerable<AppUser>>> GetUserById(int id)
        // {
        //     var users = await _users.GetUserByIdAsync(id);
        //     return Ok(users);
        // }
        [HttpGet("{username}")]
        public async Task<ActionResult<MemberDto>> GetUserByUsernameAsync(string username)
        {
            var users = await _users.GetMemberAsync(username);
            return Ok(users);
        }
    }
}