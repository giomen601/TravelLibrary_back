using FluentValidation;
using Travel.Library.Application.Contracts.Persistence;

namespace Travel.Library.Application.Features.Author.Commands.CreateAuthor;
public class CreateAuthorCommandValidator : AbstractValidator<CreateAuthorCommand>
{
  private readonly IAuthorRepository authorRepository;

  public CreateAuthorCommandValidator(IAuthorRepository authorRepository)
  {
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
}