using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale
{
    /// <summary>
    /// Validator for CreateSaleRequest that defines validation rules for sale creation.
    /// </summary>
    public class CreateSaleRequestValidator : AbstractValidator<CreateSaleRequest>
    {
        /// <summary>
        /// Initializes a new instance of the CreateSaleRequestValidator with defined validation rules.
        /// </summary>
        public CreateSaleRequestValidator()
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
    /// Validator for SaleItemRequest that defines validation rules for sale item creation.
    /// </summary>
    public class SaleItemRequestValidator : AbstractValidator<CreateSaleItemRequest>
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