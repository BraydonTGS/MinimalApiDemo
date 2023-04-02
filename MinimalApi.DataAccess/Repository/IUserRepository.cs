using MinimalApi.DataAccess.Models;

namespace MinimalApi.DataAccess.Data
{
    public interface IUserRepository
    {
        Task<bool> DeleteUserAsync(int id);
        Task<IEnumerable<UserDto>> GetAllAsync();
        Task<UserDto?> GetUserByIdAsync(int id);
        Task<bool> InsertUserAsync(UserDto user);
        Task<bool> UpdateUserAsync(UserDto user);
    }
}