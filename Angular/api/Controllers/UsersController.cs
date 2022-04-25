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

namespace Angular.api.Controllers
{
    public class UsersController : BaseApiController
    {
        private readonly IUsers<AppUser> _users;

        public UsersController(IUsers<AppUser> users)
        {
            _users = users;
        }

        [HttpGet]
        [Authorize]
        public async Task<IEnumerable<AppUser>> GetUsers()
        {
            var users = await _users.GetUsersAsync();
            return users;
        }
        [HttpGet("{id}")]

        public async Task<AppUser> GetUsers(string id)
        {
            return await _users.GetUserAsync(id);

        }
    }
}