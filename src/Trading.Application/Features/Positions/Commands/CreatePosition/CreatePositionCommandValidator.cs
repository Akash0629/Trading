using FluentValidation;

namespace Trading.Application.Features.Positions.Commands.CreatePosition
{
    public class CreatePositionCommandValidator : AbstractValidator<CreatePositionCommand>
    {
        public CreatePositionCommandValidator()
        {
            RuleFor(p => p.SecurityCode)
             .NotEmpty().WithMessage("{PropertyName} is required.")
             .NotNull()
             .MaximumLength(10).WithMessage("{PropertyName} must not exceed 10 characters.");

            RuleFor(p => p.Quantity)
             .NotNull()
             .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0.");

            RuleFor(p => p.Action)
             .NotNull()
             .IsInEnum().WithMessage("{PropertyName} is not a valid TradingType.");

            RuleFor(p => p.Operation)
             .NotNull()
             .IsInEnum().WithMessage("{PropertyName} is not a valid Operation.");

            RuleFor(p => p.TradeId)
             .NotNull()
             .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0.");
        }
    }
}
