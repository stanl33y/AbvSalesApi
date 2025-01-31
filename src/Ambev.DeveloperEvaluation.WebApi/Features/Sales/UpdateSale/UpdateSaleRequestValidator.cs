using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale
{
    /// <summary>
    /// Validator for UpdateSaleRequest that defines validation rules for updating a sale.
    /// </summary>
    public class UpdateSaleRequestValidator : AbstractValidator<UpdateSaleRequest>
    {
        /// <summary>
        /// Initializes a new instance of the UpdateSaleRequestValidator with defined validation rules.
        /// </summary>
        public UpdateSaleRequestValidator()
        {
            RuleFor(sale => sale.SaleNumber)
                .NotEmpty()
                .WithMessage("Sale number is required");

            RuleFor(sale => sale.SaleDate)
                .NotEmpty()
                .WithMessage("Sale date is required");

            RuleFor(sale => sale.CustomerId)
                .NotEmpty()
                .WithMessage("Customer ID is required");

            RuleFor(sale => sale.BranchId)
                .NotEmpty()
                .WithMessage("Branch ID is required");

            RuleForEach(sale => sale.Items)
                .SetValidator(new SaleItemRequestValidator());
        }
    }

    /// <summary>
    /// Validator for SaleItemRequest that defines validation rules for updating a sale item.
    /// </summary>
    public class SaleItemRequestValidator : AbstractValidator<UpdateSaleItemRequest>
    {
        /// <summary>
        /// Initializes a new instance of the SaleItemRequestValidator with defined validation rules.
        /// </summary>
        public SaleItemRequestValidator()
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