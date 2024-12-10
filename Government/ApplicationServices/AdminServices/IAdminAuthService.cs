namespace Government.ApplicationServices.AdminServices

{
    public interface IAdminAuthService
    {
        Task<Result<AdminLoginResponse>> GetAdminTokenAsync(string Email, string Password, CancellationToken cancellationToken = default);

    }
}
