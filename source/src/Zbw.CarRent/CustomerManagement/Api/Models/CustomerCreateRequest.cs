namespace Zbw.Carrent.CustomerManagement.Api.Models;

public record CustomerCreateRequest(
    Guid Id,
    int CustomerNr,
    string Firstname,
    string Lastname,
    string Address
);