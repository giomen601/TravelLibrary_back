using MediatR;
using Microsoft.AspNetCore.Mvc;
using Travel.Library.Application.Features.Publisher.Commands.CreatePublisher;
using Travel.Library.Application.Features.Publisher.Commands.DeletePublisher;
using Travel.Library.Application.Features.Publisher.Commands.UpdatePublisher;
using Travel.Library.Application.Features.Publisher.Queries.GetAllPublishers;
using Travel.Library.Application.Features.Publisher.Queries.GetPublisherDetail;

namespace Travel.Library.Api.Controllers;
[ApiController]
[Route("api/[controller]")]
public class PublisherController : ControllerBase
{
  private readonly IMediator mediator;

  public PublisherController
  (
    IMediator mediator
  )
  {
    this.mediator = mediator;
  }

  [HttpGet]
  public async Task<ActionResult<List<PublisherDto>>> Get()
  {
    var publisher = await mediator.Send(new GetPublisherListQuery());
    return Ok(publisher);
  }

  [HttpGet("{id}")]
  public async Task<ActionResult<PublisherDto>> Get(int id)
  {
    var author = await mediator.Send(new GetPublisherDetailQuery{Id = id});
    return Ok(author);
  }

  [HttpPost]
  [ProducesResponseType(201)]
  [ProducesResponseType(400)]
  [ProducesResponseType(StatusCodes.Status404NotFound)]
  public async Task<ActionResult> Post(CreatePublisherCommand publisher)
  {
    var response = await mediator.Send(publisher);
    return CreatedAtAction(nameof(Get), new {id = response});
  }

  [HttpPut]
  [ProducesResponseType(StatusCodes.Status204NoContent)]
  [ProducesResponseType(400)]
  [ProducesResponseType(StatusCodes.Status404NotFound)]
  [ProducesDefaultResponseType]
  public async Task<ActionResult> Put(UpdatePublisherCommand publisher)
  {
    await mediator.Send(publisher);
    return NoContent();
  }

  [HttpDelete("{id}")]
  [ProducesResponseType(StatusCodes.Status204NoContent)]
  [ProducesResponseType(StatusCodes.Status404NotFound)]
  [ProducesDefaultResponseType]
  public async Task<ActionResult> Delete(int id)
  {
    var command = new DeletePublisherCommand{Id = id};
    await mediator.Send(command);
    return NoContent();
  }
}