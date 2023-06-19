namespace Zbw.CarRent.Api;

public class CustomerResponse
{
    public Guid Id { get; set; }
    
    public string CustomerNr { get; set; }
    
    public string FirstName { get; set; }
    
    public string LastName { get; set; }
    
    public string? Address { get; set; }
}