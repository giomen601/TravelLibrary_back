using FluentValidation;
using Travel.Library.Application.Contracts.Persistence;

namespace Travel.Library.Application.Features.Book.Commands.CreateBook;
public class CreateBookCommandValidator :
AbstractValidator<CreateBookCommand>
{
  private readonly IAuthorRepository authorRepository;
  private readonly IPublisherRepository publisherRepository;

  public CreateBookCommandValidator
  (
    IAuthorRepository authorRepository,
    IPublisherRepository publisherRepository
  )
  {
    this.authorRepository = authorRepository;
    this.publisherRepository = publisherRepository;
    RuleFor(x => x.AuthorsId)
    .NotEmpty().WithMessage("Book couldn't be created without {PropertyName}")
    .NotNull()
    .MustAsync(AuthorsMustExist)
    .WithMessage("{PropertyName} must be present");

    RuleFor(x => x.PublishersId)
    .NotEmpty().WithMessage("Book culdn't be created without {PropertyName}")
    .NotNull()
    .MustAsync(PublisherMustExist)
    .WithMessage("{PropertyName} must be present");

    RuleFor(x => x.Title)
    .NotEmpty().WithMessage("{PropertyName} is required")
    .NotNull()
    .MaximumLength(45).WithMessage("{PropertyName} mut be fewer than 45 characters");
  }

  private async Task<bool> PublisherMustExist
  (
    int PublisherId,
    CancellationToken arg2
  )
  {
    var publisher = await publisherRepository.GetByIdAsync(PublisherId);
    return publisher != null;
  }

  private async Task<bool> AuthorsMustExist
  (
    List<int> authorsId,
    CancellationToken arg2
  )
  {
    foreach (var authorId in authorsId)
    {
      var author = await authorRepository.GetByIdAsync(authorId);
      if(author == null)
        return false;
    }

    return true;
  }
}