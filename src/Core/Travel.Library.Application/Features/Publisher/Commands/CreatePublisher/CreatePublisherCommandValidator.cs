using FluentValidation;
using Travel.Library.Application.Contracts.Persistence;

namespace Travel.Library.Application.Features.Publisher.Commands.CreatePublisher;
public class CreatePublisherCommandValidator :
AbstractValidator<CreatePublisherCommand>
{
  private readonly IPublisherRepository publisherRepository;

  public CreatePublisherCommandValidator
  (
    IPublisherRepository publisherRepository
  )
  {
    this.publisherRepository = publisherRepository;

    RuleFor(x => x.Name)
    .NotEmpty().WithMessage("{PropertyName} is required")
    .NotNull()
    .MaximumLength(45).WithMessage("{PropertyName} must be fewer than 45 character");

    RuleFor(x => x.HouseLocation)
    .NotEmpty().WithMessage("{PropertyName} is required")
    .NotNull()
    .MaximumLength(45).WithMessage("{PropertyName} must be fewer than 45 character");
  }
}