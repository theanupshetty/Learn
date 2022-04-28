using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Angular.Models;
using api.DTOs;

namespace Angular.interfaces
{
    public interface IUsers<T> where T : class
    {
        void Update(T model);
        Task<bool> SaveAllAsync();
        Task<IEnumerable<T>> GetUsersAsync();
        Task<T> GetUserByIdAsync(int id);
        Task<T> GetUserByUsernameAsync(string username);
        Task CreateUser(T model);

        Task<bool> UserExists(string username);

        Task<IEnumerable<MemberDto>> GetMembersAsync();
        Task<MemberDto> GetMemberAsync(string username);


    }
}