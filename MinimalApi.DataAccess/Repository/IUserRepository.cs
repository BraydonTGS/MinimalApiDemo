using MinimalApi.DataAccess.Models;

namespace MinimalApi.DataAccess.Data
{
    public interface IUserRepository
    {
        Task<int> DeleteUserAsync(int id);
        Task<IEnumerable<UserDto>> GetAllAsync();
        Task<UserDto?> GetUserByIdAsync(int id);
        Task<int> InsertUserAsync(UserDto user);
        Task<int> UpdateUserAsync(UserDto user);
    }
}