namespace Government.Contracts.Authentication
{
    public record LoginResponse
    (
         string Id,
         string Name,
         string Email,
         string Token,
         int ExpireIn

    );
}
