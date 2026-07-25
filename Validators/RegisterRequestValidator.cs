using EcommerceAPI.Models.DTOs;
using FluentValidation;

namespace EcommerceAPI.Validators
{
    public class RegisterRequestValidator : AbstractValidator<RegisterRequestDTO>
    {
        public RegisterRequestValidator() { 
         RuleFor(x => x.Name)
                .NotEmpty().WithMessage("The user name is obligatory")
                .MaximumLength(50).WithMessage("The user name can only be a maximum of 50 characters");

         RuleFor(x => x.Email)
                .NotEmpty().WithMessage("The email is obligatory")
                .EmailAddress().WithMessage("A valid email address is required");

         RuleFor(x => x.Password)
                .NotEmpty().WithMessage("The password is obligatory")
                .MinimumLength(5).WithMessage("The password must have a minimum of 5 characters");
        }
    }
}