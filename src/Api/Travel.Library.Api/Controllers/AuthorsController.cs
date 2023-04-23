using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Travel.Library.Application.Features.Author.Commands.CreateAuthor;
using Travel.Library.Application.Features.Author.Commands.DeleteAuthor;
using Travel.Library.Application.Features.Author.Commands.UpdateAuthor;
using Travel.Library.Application.Features.Author.Queries.GetAllAuthors;
using Travel.Library.Application.Features.Author.Queries.GetAuthorDetail;

namespace Travel.Library.Api.Controllers;
[ApiController]
[Route("api/[controller]")]
public class AuthorsController : ControllerBase
{
  private readonly IMediator mediator;

  public AuthorsController
  (
    IMediator mediator
  )
  {
    this.mediator = mediator;
  }

  [HttpGet]
  public async Task<ActionResult<List<AuthorDto>>> Get()
  {
    var authors = await mediator.Send(new GetAuthorsListQuery());
    return Ok(authors);
  }

  [HttpGet("{id}")]
  public async Task<ActionResult<AuthorDto>> Get(int id)
  {
    var author = await mediator.Send(new GetAuthorDetailQuery {Id = id} );
    return Ok(author);
  }

  [HttpPost]
  [ProducesResponseType(201)]
  [ProducesResponseType(400)]
  [ProducesResponseType(StatusCodes.Status404NotFound)]
  [Authorize]
  public async Task<ActionResult> Post(CreateAuthorCommand author)
  {
    var response = await mediator.Send(author);
    return CreatedAtAction(nameof(Get), new {id = response});
  }

  [HttpPut]
  [ProducesResponseType(StatusCodes.Status204NoContent)]
  [ProducesResponseType(400)]
  [ProducesResponseType(StatusCodes.Status404NotFound)]
  [ProducesDefaultResponseType]
  [Authorize]
  public async Task<ActionResult> Put(UpdateAuthorCommand author)
  {
    await mediator.Send(author);
    return NoContent();
  }

  [HttpDelete("{id}")]
  [ProducesResponseType(StatusCodes.Status204NoContent)]
  [ProducesResponseType(StatusCodes.Status404NotFound)]
  [ProducesDefaultResponseType]
  [Authorize]
  public async Task<ActionResult> Delete(int id)
  {
    var command = new DeleteAuthorCommand {Id = id };
    await mediator.Send(command);
    return NoContent(); 
  }
}