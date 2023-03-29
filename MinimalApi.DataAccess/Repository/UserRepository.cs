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
        public async Task InsertUserAsync(UserDto user) => await _repo.SaveData<UserDto>(storedProcedure: "dbo.spUser_Insert", new { user.FirstName, user.LastName, user.UserName, user.Password });
        public async Task UpdateUserAsync(UserDto user) => await _repo.SaveData<UserDto>(storedProcedure: "dbo.spUser_Update", user);
        public async Task DeleteUserAsync(int id) => await _repo.SaveData<UserDto>(storedProcedure: "dbo.spUser_Delete", new { id });
    }
}
