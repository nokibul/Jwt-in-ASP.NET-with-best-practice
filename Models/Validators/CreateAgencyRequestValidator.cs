using FluentValidation;
using Agency.Models.DTOs;

namespace Agency.Models.Validators;
public class CreateAgencyRequestValidator : AbstractValidator<CreateAgencyRequestDTO>
{
    public CreateAgencyRequestValidator()
    {
        RuleFor(agency => agency.Location).MaximumLength(100);
        RuleFor(agency => agency.Name).NotEmpty().WithMessage("You must enter name").MaximumLength(100);
        RuleFor(agency => agency.Description).NotEmpty().MaximumLength(500).WithMessage("You must enter description");
    }
}
