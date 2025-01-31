using FluentValidation;
using Ambev.DeveloperEvaluation.Application.Sales.Commands;

namespace Ambev.DeveloperEvaluation.Application.Sales.Validators
{
    /// <summary>
    /// Validator for UpdateSaleCommand that defines validation rules for updating a sale.
    /// </summary>
    public class UpdateSaleValidator : AbstractValidator<UpdateSaleCommand>
    {
        /// <summary>
        /// Initializes a new instance of the UpdateSaleValidator with defined validation rules.
        /// </summary>
        public UpdateSaleValidator()
        {
            RuleFor(command => command.SaleId)
                .NotEmpty()
                .WithMessage("Sale ID is required");

            RuleFor(command => command.SaleNumber)
                .NotEmpty()
                .WithMessage("Sale number is required");

            RuleFor(command => command.SaleDate)
                .NotEmpty()
                .WithMessage("Sale date is required");

            // Additional validation rules can be added here
        }
    }
}