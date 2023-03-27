namespace MinimalApi.Api.Api
{
    public static class ApiEndpoints
    {
        public static void ConfigureApi(this WebApplication application)
        {
            // All of my API Endpoint Mapping //
            application.MapGet(pattern: "/Users", GetUsers);
            application.MapGet(pattern: "/Users/{id}", GetUserById);
            application.MapPost(pattern: "/Users", CreateUser);
            application.MapPut(pattern: "/Users", UpdateUser);
            application.MapDelete(pattern: "/Users", DeleteUser);
            
        }

        private static async Task<IResult> GetUsers(IUserRepository data)
        {
            try
            {
                return Results.Ok(await data.GetAllAsync());
            }
            catch (Exception ex)
            {

                return Results.Problem(ex.Message);
            }
        }

        private static async Task<IResult> GetUserById(int id, IUserRepository data)
        {
            try
            {
                var result = Results.Ok(await data.GetUserByIdAsync(id));
                if (result == null) return Results.NotFound();
                return Results.Ok(result);
            }
            catch (Exception ex)
            {

                return Results.Problem(ex.Message);
            }
        }

        private static async Task<IResult> CreateUser(UserDto user, IUserRepository data)
        {
            try
            {
                await data.InsertUserAsync(user);
                return Results.Ok();
            }
            catch (Exception ex)
            {

                return Results.Problem(ex.Message);
            }
        }

        private static async Task<IResult> UpdateUser(UserDto user, IUserRepository data)
        {
            try
            {
                await data.UpdateUserAsync(user);
                return Results.Ok();
            }
            catch (Exception ex)
            {

                return Results.Problem(ex.Message);
            }
        }

        private static async Task<IResult> DeleteUser(int id, IUserRepository data)
        {
            try
            {
                await data.DeleteUserAsync(id);
                return Results.Ok();
            }
            catch (Exception ex)
            {

                return Results.Problem(ex.Message);
            }
        }
    }
}
