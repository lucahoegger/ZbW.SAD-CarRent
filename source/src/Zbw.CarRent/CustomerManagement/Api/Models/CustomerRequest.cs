namespace Zbw.CarRent.CustomerManagement.Api.Models;

public record CustomerRequest(
    Guid id, 
    string Firstname, 
    string LastName, 
    string? Address
    );