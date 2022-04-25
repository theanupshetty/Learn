using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Angular.interfaces;
using Microsoft.AspNetCore.Mvc;
using Angular.Data;
using Angular.Models;
using Microsoft.EntityFrameworkCore;

namespace Angular.implementations
{
    public class Users : IUsers<AppUser>
    {
        private readonly DataContext _context;
        public Users(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AppUser>> GetUsersAsync()
        {
            var users = await _context.Users.ToListAsync();
            return users;
        }
        public async Task<AppUser> GetUserAsync(string username)
        {
            var users = await _context.Users.FirstOrDefaultAsync(x => x.UserName == username);
            return users;
        }
        public async Task CreateUser(AppUser model)
        {
            var users = await _context.Users.AddAsync(model);
            _context.SaveChanges();
        }
        public async Task<bool> UserExists(string username)
        {
            return await _context.Users.AnyAsync(x => x.UserName == username.ToLower());

        }
    }
}