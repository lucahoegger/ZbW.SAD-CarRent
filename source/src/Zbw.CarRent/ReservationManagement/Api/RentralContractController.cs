using Microsoft.AspNetCore.Mvc;
using Zbw.Carrent.ReservationManagement.Api.Models;
using Zbw.Carrent.ReservationManagement.Domain;

namespace Zbw.Carrent.ReservationManagement.Api;

[Route("api/rental-contracts")]
[ApiController]
public class RentralContractController : ControllerBase
{
    private readonly IRentalContractRepository _repository;

    public RentralContractController(IRentalContractRepository repository)
    {
        _repository = repository;
    }

    [HttpPost]
    public IActionResult Post([FromBody] RentalContractCreateRequest value)
    {
        var newContract = new RentalContract
        {
            Id = Guid.NewGuid(),
            ReservationId = value.ReservationId,
            CreateDate = value.CreateDate
        };
        var addedContract = _repository.Add(newContract);
        return Ok(MapToResponse(addedContract));
    }

    private RentalContractResponse MapToResponse(RentalContract contract)
    {
        return new RentalContractResponse(contract.Id, contract.ReservationId, contract.CreateDate);
    }
}