using EcommerceAPI.Middleware; 
using EcommerceAPI.Models.DTOs;
using FluentValidation;

namespace EcommerceAPI.Validators
{
    public class LoginRequestValidator : AbstractValidator<LoginRequestDTO>
    {
        public LoginRequestValidator()
        {

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("The email can't be empty")
                .EmailAddress().WithMessage("A valid email address is required");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("The password can't be empty")
                .MinimumLength(5).WithMessage("The password must have a minimum of 5 characters")
                .MaximumLength(100).WithMessage("The password can only be a maximum of 100 characters");
        }
    }
    
}
