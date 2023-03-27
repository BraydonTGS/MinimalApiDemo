using MinimalApi.DataAccess.Models;

namespace MinimalApi.DataAccess.Data
{
    public interface IUserRepository
    {
        Task DeleteUserAsync(int id);
        Task<IEnumerable<UserDto>> GetAllAsync();
        Task<UserDto?> GetUserByIdAsync(int id);
        Task InsertUserAsync(UserDto user);
        Task UpdateUserAsync(UserDto user);
    }
}