using SurvayBasket.Contracts.AccountProfile.cs;

namespace SurvayBasket.ApplicationServices.UserAccount
{
    public interface IAccountService
    {

        Task<Result<UserProfileResponse>> GetUserProfileAsync();
        Task<Result> UpdateUserProfileAsync(UserUpdatedProfileRequest Request);
        Task<Result> ChangeUserPassword(ChangePassWordRequest Request);
        Task<Result> ForgetUserPassword(ForgetPasswordRequest Request); 
        Task<Result> ResetUserPassword(ResetPasswordRequest Request); 


    }
}
