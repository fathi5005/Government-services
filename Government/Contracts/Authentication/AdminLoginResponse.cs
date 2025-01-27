namespace Government.Contracts.Authentication
{
    public record AdminLoginResponse
        (
        string AdminID ,
        string FirstName, 
        string LastName, 
        string Email,
        string Token,
        int ExpireIn
        );
    
}
