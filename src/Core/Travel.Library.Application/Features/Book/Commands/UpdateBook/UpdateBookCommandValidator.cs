using FluentValidation;
using Travel.Library.Application.Contracts.Persistence;

namespace Travel.Library.Application.Features.Book.Commands.UpdateBook;
public class UpdateBookCommandValidator :
AbstractValidator<UpdateBookCommand>
{
  private readonly IAuthorRepository authorRepository;
  private readonly IBookRepository bookRepository;

  public UpdateBookCommandValidator
  (
    IAuthorRepository authorRepository,
    IBookRepository bookRepository
  )
  {
    this.authorRepository = authorRepository;
    this.bookRepository = bookRepository;

    RuleFor(x => x.AuthorsId)
    .NotEmpty().WithMessage("Book couldn't be created without {PropertyName}")
    .NotNull()
    .MustAsync(AuthorsMustExist)
    .WithMessage("{PropertyName} must be present");

    RuleFor(x => x.Title)
    .NotEmpty().WithMessage("{PropertyName} is required")
    .NotNull()
    .MaximumLength(45).WithMessage("{PropertyName} mut be fewer than 45 characters");

    RuleFor(x => x.Id)
    .NotNull()
    .MustAsync(BookMustExust)
    .WithMessage("{PropertyName} must be present");
  }

  private async Task<bool> BookMustExust(int id, CancellationToken arg2)
  {
    var book = await bookRepository.GetByIdAsync(id);
    return book != null;
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