using MinimalApi.DataAccess;
using MinimalApi.DataAccess.Data;
using MinimalApi.DataAccess.DbAccess;
using MinimalApi.DataAccess.Models;

namespace MinimalApi.Tests.Base
{
    public abstract class TestBase : IAsyncLifetime
    {
        protected readonly IUserRepository _userRepository;
        protected readonly ISqlDataAccess _sqlDataAccess;
        protected IEnumerable<UserDto> _users = Enumerable.Empty<UserDto>();
        public TestBase()
        {
            _sqlDataAccess = new SqlDataAccess(Hidden.TestDbConnectionString);
            _userRepository = new UserRepository(_sqlDataAccess);
        }


        public async Task DisposeAsync()
        {
            // Delete all the users from the database
            var allUsers = await _userRepository.GetAllAsync();
            foreach (var user in allUsers)
            {
                await _userRepository.DeleteUserAsync(user.Id);
            }
        }

        public async Task InitializeAsync()
        {
            await SeedListWithMockUsers();
            await Task.CompletedTask;
        }
        protected static UserDto CreateSingleMockUser()
        {
            var newUser = new UserDto()
            {
                FirstName = "Braydon",
                LastName = "Sutherland",
                UserName = "BeeSuth",
                Password = "Password"
            };

            return newUser;
        }

        private async Task SeedListWithMockUsers()
        {
            _users = new List<UserDto>()
            {
                new UserDto() {FirstName = "Braydon", LastName = "Sutherland", UserName = "Geo", Password = "Flambe"},
                new UserDto() {FirstName = "Colin", LastName = "Sutherland", UserName = "Colly", Password = "Goose"},
                new UserDto() {FirstName = "Sally", LastName = "Sutherland", UserName = "Salmeaux", Password = "Cheese"},
                new UserDto() {FirstName = "Devon", LastName = "Sutherland", UserName = "RiverRat", Password = "Rivers"},
                new UserDto() {FirstName = "Mackenzie", LastName = "Sutherland", UserName = "MackTown", Password = "Lincoln"}

            };
            foreach (var user in _users)
            {
                await _userRepository.InsertUserAsync(user);
            }
        }
    }
}