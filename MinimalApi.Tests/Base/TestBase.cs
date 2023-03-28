using Castle.Core.Smtp;
using MinimalApi.DataAccess.Data;
using MinimalApi.DataAccess.DbAccess;
using MinimalApi.DataAccess.Models;
using Moq;
using System.Collections;

namespace MinimalApi.Tests.Base
{
    public class TestBase
    {
        protected readonly IUserRepository _userRepository;
        protected readonly Mock<ISqlDataAccess> _sqlDataAccess;
        protected IEnumerable<UserDto> _users = Enumerable.Empty<UserDto>();

        public TestBase()
        {
            _sqlDataAccess = new Mock<ISqlDataAccess>();
            _userRepository = new UserRepository(_sqlDataAccess.Object);
            SeedListWithMockUsers();
        }

        private void SeedListWithMockUsers()
        {
            _users = new List<UserDto>()
            {
                new UserDto() {FirstName = "Braydon", LastName = "Sutherland", UserName = "Geo", Password = "Flambe"},
                new UserDto() {FirstName = "Colin", LastName = "Sutherland", UserName = "Colly", Password = "Goose"},
                new UserDto() {FirstName = "Sally", LastName = "Sutherland", UserName = "Salmeaux", Password = "Cheese"},
                new UserDto() {FirstName = "Devon", LastName = "Sutherland", UserName = "RiverRat", Password = "Rivers"},
                new UserDto() {FirstName = "Mackenzie", LastName = "Sutherland", UserName = "MackTown", Password = "Lincoln"}

            }; 
        }
    }
}