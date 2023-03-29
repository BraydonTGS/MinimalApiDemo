using Microsoft.SqlServer.Server;
using MinimalApi.DataAccess.Data;
using MinimalApi.DataAccess.DbAccess;
using MinimalApi.DataAccess.Models;
using MinimalApi.Tests.Base;
using Moq;

namespace MinimalApi.Tests.DataAccess
{
    public class UserRepositoryShould : TestBase
    {
        [Fact]
        public async Task GetAllUsers_AndReturnAllUsersAsync()
        {
            // Arrange //
            _sqlDataAccess.Setup(x => x.LoadData<UserDto>(It.IsAny<string>(), default, "Default")).ReturnsAsync(_users);

            // Act //
            var result = await _userRepository.GetAllAsync();
        
            // Assert //
            Assert.NotNull(result);
            Assert.Equal(5, result.Count());
            Assert.All(_users, u =>
            {
                Assert.Contains(u, result);
            });

            var userOne = result.FirstOrDefault();
            Assert.NotNull(userOne);
            Assert.Equal(userOne.FirstName, _users.ElementAt(0).FirstName); 
            Assert.Equal(userOne.LastName, _users.ElementAt(0).LastName);
            Assert.Equal(userOne.UserName, _users.ElementAt(0).UserName);
            Assert.Equal(userOne.Password, _users.ElementAt(0).Password);   
     
        }

        [Fact]
        public async Task GetUserById_AndReturnUser()
        {
            // Arrange //
            var expectedUser = _users.FirstOrDefault();
            _sqlDataAccess.Setup(x => x.LoadData<UserDto>(It.IsAny<string>(), It.IsAny<object>(), "Default")).ReturnsAsync(_users);

            // Act //
            var actualUser = await _userRepository.GetUserByIdAsync(1);

            // Assert //
            Assert.NotNull(expectedUser);
            Assert.NotNull(actualUser);
            Assert.Equal(expectedUser, actualUser);
            Assert.Equal(expectedUser.FirstName, actualUser.FirstName);
            Assert.Equal(expectedUser.LastName, actualUser.LastName);    
        }

        [Fact]
        public async Task CreateUser_ShouldAddNewUser()
        {
            // Arrange
            var newUser = new UserDto()
            {
                Id = 1,
                FirstName = "Braydon",
                LastName = "Sutherland",
                UserName = "BeeSuth",
                Password = "Password"
            };
            _sqlDataAccess.Setup(x => x.SaveData<UserDto>(It.IsAny<string>(), It.IsAny<object>(), "Default")); 

            // Act //
            await _userRepository.InsertUserAsync(newUser);
   
            // Assert //
            _sqlDataAccess.Verify(x => x.SaveData<UserDto>(It.IsAny<string>(), It.IsAny<object>(), "Default"), Times.Once);

            
        }
    }
}
