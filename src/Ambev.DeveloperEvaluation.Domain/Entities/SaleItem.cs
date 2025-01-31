using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

/// <summary>
/// Represents an item included in a sale with details about the product, quantity, unit price, discount, and total amount.
/// This entity follows domain-driven design principles and includes business rules validation.
/// </summary>
public class SaleItem : BaseEntity
{
    /// <summary>
    /// Get the unique identifier of the sale item.
    /// </summary>
    public Guid SaleId { get; private set; }

    /// <summary>
    /// Gets the unique identifier of the product.
    /// </summary>
    public Guid ProductId { get; private set; }

    /// <summary>
    /// Gets the quantity of the product in the sale.
    /// </summary>
    public int Quantity { get; private set; }

    /// <summary>
    /// Gets the unit price of the product.
    /// </summary>
    public decimal UnitPrice { get; private set; }

    /// <summary>
    /// Gets the discount applied to the product.
    /// </summary>
    public decimal Discount { get; private set; }

    /// <summary>
    /// Gets the total amount for the product in the sale.
    /// </summary>
    public decimal TotalAmount { get; private set; }

    /// <summary>
    /// Initializes a new instance of the SaleItem class.
    /// </summary>
    /// <param name="productId">The unique identifier of the product.</param>
    /// <param name="quantity">The quantity of the product in the sale.</param>
    /// <param name="unitPrice">The unit price of the product.</param>
    /// <exception cref="ArgumentException">Thrown when quantity or unit price is invalid.</exception>
    public SaleItem(Guid productId, int quantity, decimal unitPrice)
    {
        ValidateQuantity(quantity);
        ValidateUnitPrice(unitPrice);

        Id = Guid.NewGuid();
        ProductId = productId;
        Quantity = quantity;
        UnitPrice = unitPrice;
        Discount = CalculateDiscount();
        TotalAmount = CalculateTotalAmount();
    }

    private static void ValidateQuantity(int quantity)
    {
        if (quantity <= 0 || quantity > 20)
        {
            throw new InvalidOperationException("Quantity must be between 1 and 20.");
        }
    }

    private static void ValidateUnitPrice(decimal unitPrice)
    {
        if (unitPrice <= 0)
        {
            throw new ArgumentException("Unit price must be greater than zero.");
        }
    }

    /// <summary>
    /// Calculates the discount applied to the product based on the quantity.
    /// </summary>
    /// <returns>The discount amount.</returns>
    private decimal CalculateDiscount()
    {
        if (Quantity >= 10 && Quantity <= 20)
            return UnitPrice * Quantity * 0.20m;
        if (Quantity >= 4)
            return UnitPrice * Quantity * 0.10m;
        return 0;
    }

    /// <summary>
    /// Calculates the total amount for the product in the sale.
    /// </summary>
    /// <returns>The total amount for the product.</returns>
    private decimal CalculateTotalAmount()
    {
        return (UnitPrice * Quantity) - Discount;
    }
}