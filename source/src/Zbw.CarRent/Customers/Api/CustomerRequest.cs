namespace Zbw.CarRent.Api;

public record CustomerRequest(
    Guid id, 
    string Firstname, 
    string LastName, 
    string? Address
    );