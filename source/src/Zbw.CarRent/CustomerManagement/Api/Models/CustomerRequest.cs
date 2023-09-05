namespace Zbw.Carrent.CustomerManagement.Api.Models
{
    public record CustomerRequest(
        Guid Id,
        string Firstname,
        string Lastname,
        string Address
    );
}
