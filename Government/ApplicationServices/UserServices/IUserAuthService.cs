using Government.Abstractions;

namespace Government.ApplicationServices.UserServices
{
    public interface IUserAuthService
    {
        Task<Result<LoginResponse>> GetUserTokenAsync(string Email, string Password, CancellationToken cancellationToken = default);

    }
}
