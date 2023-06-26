namespace Zbw.CarRent.CustomerManagement.Api.Models;

public record CustomerResponse
(
     Guid Id,
     string CustomerNr,
     string FirstName,
     string LastName,
     string? Address
);