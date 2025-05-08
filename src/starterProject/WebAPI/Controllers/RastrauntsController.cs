using Application.Features.Rastraunts.Commands.Create;
using Application.Features.Rastraunts.Commands.Delete;
using Application.Features.Rastraunts.Commands.Update;
using Application.Features.Rastraunts.Queries.GetById;
using Application.Features.Rastraunts.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RastrauntsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateRastrauntCommand createRastrauntCommand)
    {
        CreatedRastrauntResponse response = await Mediator.Send(createRastrauntCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateRastrauntCommand updateRastrauntCommand)
    {
        UpdatedRastrauntResponse response = await Mediator.Send(updateRastrauntCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedRastrauntResponse response = await Mediator.Send(new DeleteRastrauntCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdRastrauntResponse response = await Mediator.Send(new GetByIdRastrauntQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListRastrauntQuery getListRastrauntQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListRastrauntListItemDto> response = await Mediator.Send(getListRastrauntQuery);
        return Ok(response);
    }
}