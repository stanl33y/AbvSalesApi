using Ambev.DeveloperEvaluation.Application.Sales.GetSale;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.Validators
{
    /// <summary>
    /// Validator for GetSaleCommand that defines validation rules for retrieving a sale.
    /// </summary>
    public class GetSaleValidator : AbstractValidator<GetSaleCommand>
    {
        public GetSaleValidator()
        {
            RuleFor(command => command.SaleId)
                .NotEmpty()
                .WithMessage("Sale ID is required");
        }
    }
}