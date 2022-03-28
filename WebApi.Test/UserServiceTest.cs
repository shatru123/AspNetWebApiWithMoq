using NUnit.Framework;
using System.Threading.Tasks;
using WebApi.Api.Services;
using WebApi.Api.Models;
using Moq;
using Microsoft.Extensions.Logging;
using WebApi.Api.DbManager;
using System.Collections.Generic;

namespace WebApi.Test
{
    public class UserServiceTest
    {
        private readonly UserService _userService;
        private readonly Mock<ILogger<DbManager>> _loggerMock = new Mock<ILogger<DbManager>>();
        private readonly Mock<IUserService> _userServiceMock = new Mock<IUserService>();
        private readonly Mock<IDbManager> _dbManagerMock = new Mock<IDbManager>();
        public UserServiceTest()
        {
            _userService = new UserService(_dbManagerMock.Object);
        }

        [Test] 
        public async Task GetSingleUser_Test()
        {
            //Arrange
            var userId = System.Guid.NewGuid().ToString();
            var userData = new User()
            {
                Id =  userId,
                Address = "Pune",
                ContactNo = "1234567890",
                Email = "ambhoreshatrughna@gmail.com",
                Name = "Shatrughna Shivaji Ambhore"
            };
            _dbManagerMock.Setup(u => u.GetSingleUser(userId)).ReturnsAsync(userData);
            //Act
            var user = await _userService.GetSingleUser(userId);
            //Assert 
            Assert.AreEqual(userId, user.Id);
        }
        
        [Test] 
        public async Task GetAllUser_Test()
        {
            //Arrange
            var userList = new List<User>()
            {
                new User()
                {
                    Id = System.Guid.NewGuid().ToString(),
                    Address = "Pune",
                    ContactNo = "1234567890",
                    Email = "ambhoreshatrughna@gmail.com",
                    Name = "Shatrughna Shivaji Ambhore"
                },
                new User()
                {
                    Id = System.Guid.NewGuid().ToString(),
                    Address = "Mumbai",
                    ContactNo = "11111110",
                    Email = "user@gmail.com",
                    Name = "User Name"
                }
            };
           
            _dbManagerMock.Setup(u => u.GetAllUsers()).ReturnsAsync(userList);
            //Act
            var users = await _userService.GetAllUsers();
            //Assert 
            Assert.IsNotNull(users);
        }
        
        [Test] 
        public async Task AddUser_Test()
        {
            //Arrange
            var user = new User()
            {
                Id = System.Guid.NewGuid().ToString(),
                Address = "Pune",
                ContactNo = "1234567890",
                Email = "ambhoreshatrughna@gmail.com",
                Name = "Shatrughna Shivaji Ambhore"
            };

            _dbManagerMock.Setup(u => u.AddNewUser(user)).ReturnsAsync(true);
            //Act
            var users = await _userService.AddNewUser(user);
            //Assert 
            Assert.IsTrue(users);
        }
        public async Task UpdateUser_Test()
        {
            //Arrange
            var user = new User()
            {                
                Address = "Pune MH",
                ContactNo = "1234567890",
                Email = "useremail@gmail.com",
                Name = "Shatrughna Ambhore"
            };

            _dbManagerMock.Setup(u => u.UpdateUser(user)).ReturnsAsync(true);
            //Act
            var users = await _userService.UpdateUser(user);
            //Assert 
            Assert.IsTrue(users);
        }
        
        [Test] 
        public async Task DeleteUser_Test()
        {
            //Arrange
            var userId = System.Guid.NewGuid().ToString();

            _dbManagerMock.Setup(u => u.DeleteUser(userId)).ReturnsAsync(true);
            //Act
            var result = await _userService.DeleteUser(userId);
            //Assert 
            Assert.IsTrue(result);
        }
    }
}