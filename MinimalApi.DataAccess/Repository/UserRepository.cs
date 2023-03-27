using MinimalApi.DataAccess.DbAccess;
using MinimalApi.DataAccess.Models;

namespace MinimalApi.DataAccess.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly ISqlDataAccess _repo;

        public UserRepository(ISqlDataAccess repo)
        {
            _repo = repo;
        }
        public async Task<IEnumerable<UserDto>> GetAllAsync() => await _repo.LoadData<UserDto>(storedProcedure: "dbo.spUser_GetAll");
        public async Task<UserDto?> GetUserByIdAsync(int id)
        {
            var result = await _repo.LoadData<UserDto>(storedProcedure: "dbo.spUser.Get", new { id });
            var user = result.FirstOrDefault();
            if (user == null)
            {
                return null;
            }
            return user;
        }
        public Task InsertUserAsync(UserDto user) => _repo.SaveData(storedProcedure: "dbo.spUser_Insert", new { user.FirstName, user.LastName, user.UserName, user.Password });
        public Task UpdateUserAsync(UserDto user) => _repo.SaveData(storedProcedure: "dbo.spUser_Update", user);
        public Task DeleteUserAsync(int id) => _repo.SaveData(storedProcedure: "dbo.spUser_Delete", new { id });
    }
}
