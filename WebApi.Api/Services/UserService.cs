using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Api.Models;
using System.IO;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;
using WebApi.Api.DbManager;

namespace WebApi.Api.Services
{
    public class UserService : IUserService
    {
        
        private readonly IDbManager _dbManager;
        string filePath = string.Empty;
        public UserService(IDbManager dbManager)
        {
            this._dbManager = dbManager;
            
        }
        public async Task<User> GetSingleUser(string userId)
        {
            return await _dbManager.GetSingleUser(userId);                     
        }
        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _dbManager.GetAllUsers();
        }
        
        public async Task<bool> AddNewUser(User userData)
        {
            return await _dbManager.AddNewUser(userData);                               
        }
        
        public async Task<bool> UpdateUser(User userData)
        {
            return await _dbManager.UpdateUser(userData);
        }
        public async Task<bool> DeleteUser(string userId)
        {
            return await _dbManager.DeleteUser(userId);
        }
    }
}