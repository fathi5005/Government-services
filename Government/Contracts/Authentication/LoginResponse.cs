namespace Government.Contracts.Authentication
{
    public record LoginResponse
    (
         string Id,
         string Name,
         string NationalId,
         string PhoneNumber,
         string Email,     
         string Token,
         int ExpireIn

    );
}



