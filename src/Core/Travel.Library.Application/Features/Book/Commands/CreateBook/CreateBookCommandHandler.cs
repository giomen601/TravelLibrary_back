using AutoMapper;
using MediatR;
using Travel.Library.Application.Contracts.Persistence;
using Travel.Library.Application.Exceptions;

namespace Travel.Library.Application.Features.Book.Commands.CreateBook;
public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, int>
{
  private readonly IMapper mapper;
  private readonly IBookRepository bookRepository;
  private readonly IPublisherRepository publisherRepository;
  private readonly IAuthorRepository authorRepository;

  public CreateBookCommandHandler
  (
    IMapper mapper,
    IBookRepository bookRepository,
    IPublisherRepository publisherRepository,
    IAuthorRepository authorRepository
  )
  {
    this.mapper = mapper;
    this.bookRepository = bookRepository;
    this.publisherRepository = publisherRepository;
    this.authorRepository = authorRepository;
  }

  public async Task<int> Handle
  (
    CreateBookCommand request,
    CancellationToken cancellationToken
  )
  {
    //Validate incoming data
    var validator = new CreateBookCommandValidator(authorRepository, publisherRepository);
    var validationResult = await validator.ValidateAsync(request);

    if(validationResult.Errors.Any())
    {
      throw new BadRequestException("Invalid book", validationResult);
    }

    //convert to domain entity object
    var bookToCreate = mapper.Map<Domain.Entities.Book>(request);

    //add to data base
    await bookRepository.CreateAsync(bookToCreate);

    return bookToCreate.Id;
  }
}