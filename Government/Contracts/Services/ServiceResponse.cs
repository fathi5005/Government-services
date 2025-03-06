namespace Government.Contracts.Services
{
    public record ServiceResponse
     (  
        int Id ,
        string ServiceName , 
        string ServiceDescription,
        decimal Fee,
        string ProcessingTime,
        string ContactInfo
        );

}

