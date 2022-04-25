using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Angular.Models;

namespace Angular.interfaces
{
    public interface IUsers<T> where T : class
    {
        Task<IEnumerable<T>> GetUsersAsync();
        Task<T> GetUserAsync(string username);
        Task CreateUser(T model);

        Task<bool> UserExists(string username);
    }
}