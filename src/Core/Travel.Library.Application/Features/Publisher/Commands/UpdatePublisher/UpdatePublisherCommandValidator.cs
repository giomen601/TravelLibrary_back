using FluentValidation;

namespace Travel.Library.Application.Features.Publisher.Commands.UpdatePublisher;
public class UpdatePublisherCommandValidator :
AbstractValidator<UpdatePublisherCommand>
{
    public UpdatePublisherCommandValidator()
    {
      RuleFor(x => x.Id)
      .NotEmpty().WithMessage("{PropertyName} is required")
      .NotNull();

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