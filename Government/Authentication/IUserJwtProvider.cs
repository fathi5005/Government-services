namespace Government.Authentication

{
    public interface IUserJwtProvider
    {

        (string token, int expireIn) GenerateToken(ApplicationUser user);
    }
}
