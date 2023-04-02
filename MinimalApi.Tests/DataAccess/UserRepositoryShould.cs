using MinimalApi.Tests.Base;

namespace MinimalApi.Tests.DataAccess
{
    public class UserRepositoryShould : TestBase
    {

        [Fact]
        public async Task GetAllUsers_AndReturnAllUsersAsync()
        {
            // Act //
            var result = await _userRepository.GetAllAsync();

            // Assert //
            Assert.NotNull(result);
            Assert.Equal(5, result.Count());

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
            // Act //
            var users = await _userRepository.GetAllAsync();
            var expectedUser = users?.FirstOrDefault();

            // Assert //
            Assert.NotNull(expectedUser);

            // Act //
            var actualUser = await _userRepository.GetUserByIdAsync(expectedUser.Id);

            // Assert //
            Assert.NotNull(actualUser);
            Assert.Equal(expectedUser.FirstName, actualUser.FirstName);
            Assert.Equal(expectedUser.LastName, actualUser.LastName);
            Assert.Equal(expectedUser.UserName, actualUser.UserName);
        }

        [Fact]
        public async Task CreateUser_ShouldReturnTrue()
        {
            // Arrange //
            var newUser = TestBase.CreateSingleMockUser();

            // Act //
            var results = await _userRepository.InsertUserAsync(newUser);

            // Assert //
            Assert.True(results);
        }

        [Fact]
        public async Task UpdateUser_ShouldReturnTrue()
        {
            // Act //
            var users = await _userRepository.GetAllAsync();
            var userToUpdate = users?.FirstOrDefault();

            // Assert //
            Assert.NotNull(userToUpdate);

            // Arrange //
            userToUpdate.UserName = "Geomatics";
            userToUpdate.FirstName = "Bee";
            userToUpdate.LastName = "Sutherland";

            // Act //
            var result = await _userRepository.UpdateUserAsync(userToUpdate);

            // Assert //
            Assert.True(result);
        }

        [Fact]
        public async Task DeleteUser_ShouldReturnTrue()
        {
            // Act //
            var users = await _userRepository.GetAllAsync();
            var userToDelete = users?.FirstOrDefault();

            // Assert //
            Assert.NotNull(userToDelete);

            // Act //
            var result = await _userRepository.DeleteUserAsync(userToDelete.Id);

            // Assert //
            Assert.True(result);
        }
    }
}
