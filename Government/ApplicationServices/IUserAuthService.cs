namespace Government.Services
{
    public interface IUserAuthService
    {
        Task<LoginResponse?> GetUserTokenAsync(string Email, string Password, CancellationToken cancellationToken = default);

    }
}
