namespace Government.ApplicationServices
{
    public interface IAdminAuthService
    {
        Task<AdminLoginResponse?> GetAdminTokenAsync(string Email, string Password, CancellationToken cancellationToken = default);

    }
}
