using EcommerceAPI.Middleware;
using EcommerceAPI.Models.DTOs;
using FluentValidation;

namespace EcommerceAPI.Validators
{
    public class ProductsRequestValidator : AbstractValidator<ProductRequestDTO>
    {
        public ProductsRequestValidator()
        {

            RuleFor(x => x.ProductName)
                .NotEmpty().WithMessage("Product name is required")
                .Length(3, 100).WithMessage("Product name must be between 3 and 100 characters");


            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Product price must be greater than zero");
               

            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage("Product description cannot exceed 500 characters");

        }
    }
}
