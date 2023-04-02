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
            var result = await _repo.LoadData<UserDto>(storedProcedure: "dbo.spUser_Get", new { id });
            var user = result.FirstOrDefault();
            if (user == null)
            {
                return null;
            }
            return user;
        }
        public async Task<bool> InsertUserAsync(UserDto user)
        {
            try
            {
                var result = await _repo.SaveData<UserDto>(storedProcedure: "dbo.spUser_Insert", new { user.FirstName, user.LastName, user.UserName, user.Password });
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public async Task<bool> UpdateUserAsync(UserDto user)
        {
            try
            {
                var result = await _repo.SaveData<UserDto>(storedProcedure: "dbo.spUser_Update", user);
                return result;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }

        }
        public async Task<bool> DeleteUserAsync(int id) => await _repo.SaveData<UserDto>(storedProcedure: "dbo.spUser_Delete", new { id });
    }
}
