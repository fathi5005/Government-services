namespace Government.Services
{
    public interface IAuthService
    {
        Task<LoginResponse?> GetTokenAsync(string Email, string Password, CancellationToken cancellationToken = default);

    }
}
