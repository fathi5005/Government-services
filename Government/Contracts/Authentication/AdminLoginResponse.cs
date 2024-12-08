namespace Government.Contracts.Authentication
{
    public record AdminLoginResponse
        (
        int AdminID ,
        string AdminName, 
        string Email,
        string Token,
        int ExpireIn
        );
    
}
