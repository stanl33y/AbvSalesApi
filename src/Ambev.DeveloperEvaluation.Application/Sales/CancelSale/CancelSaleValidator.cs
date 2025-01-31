using Ambev.DeveloperEvaluation.Application.Sales.Commands;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.Validators
{
    /// <summary>
    /// Validator for CancelSaleCommand that defines validation rules for canceling a sale.
    /// </summary>
    public class CancelSaleValidator : AbstractValidator<CancelSaleCommand>
    {
        /// <summary>
        /// Initializes a new instance of the CancelSaleValidator with defined validation rules.
        /// </summary>
        public CancelSaleValidator()
        {
            RuleFor(command => command.SaleId)
                .NotEmpty()
                .WithMessage("Sale ID is required");
        }
    }
}