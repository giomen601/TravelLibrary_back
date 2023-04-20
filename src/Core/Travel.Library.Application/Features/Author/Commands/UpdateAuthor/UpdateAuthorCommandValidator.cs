using FluentValidation;
using Travel.Library.Application.Contracts.Persistence;

namespace Travel.Library.Application.Features.Author.Commands.UpdateAuthor;
public class UpdateAuthorCommandValidator :
AbstractValidator<UpdateAuthorCommand>
{
  private readonly IAuthorRepository authorRepository;

  public UpdateAuthorCommandValidator
  (
    IAuthorRepository authorRepository
  )
  {
    RuleFor(x => x.Id)
    .NotNull()
    .MustAsync(AuthorMustExist)
    .WithMessage("{PropertyName} must be present");

    RuleFor(x => x.Name)
    .NotEmpty().WithMessage("{PropertyName} is required")
    .NotNull()
    .MaximumLength(45).WithMessage("{PropertyName} must be fewer than 45 characters");

    RuleFor(x => x.Lastname)
    .NotEmpty().WithMessage("{PropertyName} is required")
    .NotNull()
    .MaximumLength(45).WithMessage("{PropertyName} must be fewer than 45 characters");
    this.authorRepository = authorRepository;
  }

  private async Task<bool> AuthorMustExist(int id, CancellationToken arg2)
  {
    var author = await authorRepository.GetByIdAsync(id);
    return author != null;
  }
}