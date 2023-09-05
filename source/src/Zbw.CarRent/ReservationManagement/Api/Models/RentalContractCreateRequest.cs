namespace Zbw.Carrent.ReservationManagement.Api.Models;

public record RentalContractCreateRequest(Guid Id, Guid ReservationId, DateTime CreateDate);