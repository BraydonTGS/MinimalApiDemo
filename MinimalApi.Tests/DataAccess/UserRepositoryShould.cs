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
        public async Task GetAllUsers_ShouldReturnAllUsersAsync()
        {
            // Arrange //
            _sqlDataAccess.Setup(x => x.LoadData<UserDto>(It.IsAny<string>(), default, "Default"))
                .ReturnsAsync(_users);

            // Act //
            var actualUsers = await _userRepository.GetAllAsync();

            // Assert //
            Assert.NotNull(actualUsers);
        }
    }
}
