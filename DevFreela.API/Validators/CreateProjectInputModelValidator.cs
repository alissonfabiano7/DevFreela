using DevFreela.API.Models;
using FluentValidation;
using Microsoft.Extensions.Options;

namespace DevFreela.API.Validators
{
    public class CreateProjectInputModelValidator : AbstractValidator<CreateProjectInputModel>
    {
        public CreateProjectInputModelValidator(IServiceProvider serviceProvider)
        {
            var options = serviceProvider.GetService<IOptions<FreelanceTotalCostConfig>>();

            RuleFor(p => p.Title)
                .NotEmpty().WithMessage("The Title is required.")
                .MinimumLength(3).WithMessage("The Title must be at least 3 characters long.")
                .MaximumLength(50).WithMessage("The Title must not exceed 50 characters.");

            RuleFor(p => p.Description)
                .MaximumLength(200).WithMessage("The Description must not exceed 200 characters.");

            RuleFor(p => p.TotalCost)
                .GreaterThan(0).WithMessage("The Total Cost must be greater than zero.");

            RuleFor(p => p.StartDate)
                .LessThan(p => p.EndDate).WithMessage("The Start Date must be earlier than the End Date.");

            RuleFor(p => p.ClientId)
                .GreaterThan(0).WithMessage("The Client ID must be a valid positive integer.");

            RuleFor(p => p.FreelancerId)
                .GreaterThan(0).WithMessage("The Freelancer ID must be a valid positive integer.");

            RuleFor(p => p.TotalCost)
                .LessThanOrEqualTo(options.Value.MaximumValue).WithMessage($"The Total Cost must be at least {options.Value.MaximumValue}.");
            RuleFor(p => p.TotalCost)
                .GreaterThanOrEqualTo(options.Value.MinimumValue).WithMessage($"The Total Cost must not exceed {options.Value.MinimumValue}.");
        }
    }
}
