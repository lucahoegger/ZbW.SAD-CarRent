namespace Zbw.Carrent.CustomerManagement.Api.Models;

public record CustomerResponse(
    Guid Id,
    int CustomerNr,
    string FirstName,
    string LastName,
    string? Address
);