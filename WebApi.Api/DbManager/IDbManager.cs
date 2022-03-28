using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Api.Models;

namespace WebApi.Api.DbManager
{
    public interface IDbManager
    {
        public Task<User> GetSingleUser(string userId);
        public Task<IEnumerable<User>> GetAllUsers();
        public Task<bool> AddNewUser(User userData);
        public Task<bool> UpdateUser(User userData);
        public Task<bool> DeleteUser(string userId);
    }
}
