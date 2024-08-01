namespace LibraryManagementSystem.Application.Auth
{
    public interface IJwtToken
    {
        Task<string> GenerateToken(string userId, string username);
    }
}
