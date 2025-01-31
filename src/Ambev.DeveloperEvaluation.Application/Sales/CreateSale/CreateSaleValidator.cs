using Ambev.DeveloperEvaluation.Application.Sales.Commands;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.Validators
{
    /// <summary>
    /// Validator for CreateSaleCommand that defines validation rules for creating a sale.
    /// </summary>
    public class CreateSaleValidator : AbstractValidator<CreateSaleCommand>
    {
        /// <summary>
        /// Initializes a new instance of the CreateSaleValidator with defined validation rules.
        /// </summary>
        public CreateSaleValidator()
        {
            RuleFor(command => command.SaleNumber)
                .NotEmpty()
                .WithMessage("Sale number is required");

            RuleFor(command => command.SaleDate)
                .NotEmpty()
                .WithMessage("Sale date is required");

            RuleFor(command => command.CustomerId)
                .NotEmpty()
                .WithMessage("Customer ID is required");

            RuleFor(command => command.BranchId)
                .NotEmpty()
                .WithMessage("Branch ID is required");

            RuleForEach(command => command.Items)
                .SetValidator(new SaleItemValidator());
        }
    }

    /// <summary>
    /// Validator for SaleItemCommand that defines validation rules for creating a sale item.
    /// </summary>
    public class SaleItemValidator : AbstractValidator<SaleItemCommand>
    {
        /// <summary>
        /// Initializes a new instance of the SaleItemValidator with defined validation rules.
        /// </summary>
        public SaleItemValidator()
        {
            RuleFor(item => item.ProductId)
                .NotEmpty()
                .WithMessage("Product ID is required");

            RuleFor(item => item.Quantity)
                .GreaterThan(0)
                .WithMessage("Quantity must be greater than zero");

            RuleFor(item => item.UnitPrice)
                .GreaterThan(0)
                .WithMessage("Unit price must be greater than zero");
        }
    }
}