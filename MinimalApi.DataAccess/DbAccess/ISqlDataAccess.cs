namespace MinimalApi.DataAccess.DbAccess
{
    public interface ISqlDataAccess
    {
        Task<IEnumerable<T>> LoadData<T>(string storedProcedure, object? parameters = null);
        Task<bool> SaveData<T>(string storedProcedure, object? parameters = null);
    }
}