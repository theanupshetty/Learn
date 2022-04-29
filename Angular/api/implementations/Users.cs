using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Angular.interfaces;
using Microsoft.AspNetCore.Mvc;
using Angular.Data;
using Angular.Models;
using Microsoft.EntityFrameworkCore;
using api.DTOs;
using AutoMapper.QueryableExtensions;
using AutoMapper;

namespace Angular.implementations
{
    public class Users : IUsers<AppUser>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public Users(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AppUser>> GetUsersAsync()
        {
            var users = await _context.Users.Include(p => p.Photos).ToListAsync();
            return users;
        }
        public async Task<AppUser> GetUserByUsernameAsync(string username)
        {
            var users = await _context.Users.Include(p => p.Photos).
            FirstOrDefaultAsync(x => x.UserName == username);
            return users;
        }
        public async Task<AppUser> GetUserByIdAsync(int id)
        {
            var users = await _context.Users.FindAsync(id);
            return users;
        }
        public async Task CreateUser(AppUser model)
        {
            var users = await _context.Users.AddAsync(model);
            bool res = await SaveAllAsync();
        }
        public void Update(AppUser model)
        {

            _context.Entry(model).State = EntityState.Modified;
            //bool res = await SaveAllAsync();
        }
        public async Task<bool> UserExists(string username)
        {
            return await _context.Users.AnyAsync(x => x.UserName == username.ToLower());

        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<MemberDto>> GetMembersAsync()
        {
            return await _context.Users
            .ProjectTo<MemberDto>(_mapper.ConfigurationProvider)
            .ToListAsync();
        }

        public async Task<MemberDto> GetMemberAsync(string username)
        {
            return await _context.Users.Where(x => x.UserName == username)
            .ProjectTo<MemberDto>(_mapper.ConfigurationProvider)
            .SingleOrDefaultAsync();
        }
    }
}