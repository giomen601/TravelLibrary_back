using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Travel.Library.Application.Features.Book.Commands.CreateBook;
using Travel.Library.Application.Features.Book.Commands.DeleteBook;
using Travel.Library.Application.Features.Book.Commands.UpdateBook;
using Travel.Library.Application.Features.Book.Queries.GetAllBooks;
using Travel.Library.Application.Features.Book.Queries.GetBookDetail;

namespace Travel.Library.Api.Controllers;
[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
  private readonly IMediator mediator;

  public BooksController
  (
    IMediator mediator
  )
  {
    this.mediator = mediator;
  }

  [HttpGet]
  public async Task<ActionResult<List<BookDto>>> Get()
  {
    var books = await mediator.Send(new GetBooksListQuery());
    return Ok(books);
  }

  [HttpGet("{id}")]
  public async Task<ActionResult<BookDto>> Get(int id)
  {
    var book = await mediator.Send(new GetBookDetailQuery{ Id = id});
    return Ok(book);
  }

  [HttpPost]
  [ProducesResponseType(201)]
  [ProducesResponseType(400)]
  [ProducesResponseType(StatusCodes.Status404NotFound)]
  [Authorize]
  public async Task<ActionResult> Post(CreateBookCommand book)
  {
    var response = await mediator.Send(book);
    return CreatedAtAction(nameof(Get), new {id = response});
  }

  [HttpPut]
  [ProducesResponseType(StatusCodes.Status204NoContent)]
  [ProducesResponseType(400)]
  [ProducesResponseType(StatusCodes.Status404NotFound)]
  [ProducesDefaultResponseType]
  [Authorize]
  public async Task<ActionResult> Put(UpdateBookCommand book)
  {
    await mediator.Send(book);
    return NoContent();
  }

  [HttpDelete("{id}")]
  [ProducesResponseType(StatusCodes.Status204NoContent)]
  [ProducesResponseType(StatusCodes.Status404NotFound)]
  [ProducesDefaultResponseType]
  [Authorize]
  public async Task<ActionResult> Delete(int id)
  {
    var command = new DeleteBookCommand {Id = id};
    await mediator.Send(command);
    return NoContent();
  }
}