namespace Government.Authentication
{
    public interface IAdminJwtProvider
    {
        (string token, int expireIn) GenerateAdminToken(AppUser admin);

    }
}
