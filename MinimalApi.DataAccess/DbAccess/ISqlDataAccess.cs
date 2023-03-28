namespace MinimalApi.DataAccess.DbAccess
{
    public interface ISqlDataAccess
    {
        Task<IEnumerable<T>> LoadData<T>(string storedProcedure, object? parameters = null, string connectionId = "Default");
        Task<int> SaveData<T>(string storedProcedure, object? parameters = null, string connectionId = "Default");
    }
}