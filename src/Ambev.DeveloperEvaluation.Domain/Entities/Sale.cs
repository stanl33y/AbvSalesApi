using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

/// <summary>
/// Represents a sale in the system with details about the sale, customer, branch, and items.
/// This entity follows domain-driven design principles and includes business rules validation.
/// </summary>
public class Sale : BaseEntity
{
    /// <summary>
    /// Gets the unique sale number.
    /// </summary>
    public string SaleNumber { get; set; }

    /// <summary>
    /// Gets the date and time when the sale was made.
    /// </summary>
    public DateTime SaleDate { get; set; }

    /// <summary>
    /// Gets the unique identifier of the customer who made the sale.
    /// </summary>
    public Guid CustomerId { get; set; }

    /// <summary>
    /// Gets the total amount of the sale.
    /// </summary>
    public decimal TotalAmount { get; private set; }

    /// <summary>
    /// Gets the unique identifier of the branch where the sale was made.
    /// </summary>
    public Guid BranchId { get; set; }

    /// <summary>
    /// Gets the collection of items included in the sale.
    /// </summary>
    public ICollection<SaleItem> Items { get; private set; }

    /// <summary>
    /// Gets a value indicating whether the sale is cancelled.
    /// </summary>
    public bool IsCancelled { get; private set; }

    /// <summary>
    /// Required by EF Core.
    /// Initializes a new instance of the Sale class without parameters.
    /// </summary>
    private Sale()
    {
        SaleNumber = ""; // Init with an empty string to avoid NullReferenceException
        Items = new List<SaleItem>(); // Init the collection to avoid NullReferenceException
    }

    /// <summary>
    /// Initializes a new instance of the Sale class.
    /// </summary>
    /// <param name="saleNumber">The unique sale number.</param>
    /// <param name="saleDate">The date and time when the sale was made.</param>
    /// <param name="customerId">The unique identifier of the customer who made the sale.</param>
    /// <param name="branchId">The unique identifier of the branch where the sale was made.</param>
    /// <param name="items">The collection of items included in the sale.</param>
    public Sale(string saleNumber, DateTime saleDate, Guid customerId, Guid branchId, ICollection<SaleItem> items)
        : this()
    {
        Id = Guid.NewGuid();
        SaleNumber = saleNumber;
        SaleDate = saleDate;
        CustomerId = customerId;
        BranchId = branchId;
        IsCancelled = false;
        Items = items;
        TotalAmount = CalculateTotalAmount();
    }

    /// <summary>
    /// Adds an item to the sale.
    /// </summary>
    /// <param name="item">The sale item to add.</param>
    public void AddItem(SaleItem item)
    {
        var existingItem = Items.FirstOrDefault(i => i.ProductId == item.ProductId);
        var newQuantity = existingItem != null ? existingItem.Quantity + item.Quantity : item.Quantity;

        if (newQuantity > 20)
        {
            throw new InvalidOperationException($"Cannot add more than 20 items for the product {item.ProductId}.");
        }

        Items.Add(item);
        TotalAmount = CalculateTotalAmount();
    }

    /// <summary>
    /// Calculates the total amount of the sale based on the items included.
    /// </summary>
    /// <returns>The total amount of the sale.</returns>
    private decimal CalculateTotalAmount()
    {
        return Items.Sum(item => item.TotalAmount);
    }

    /// <summary>
    /// Cancels the sale.
    /// Changes the sale status to cancelled.
    /// </summary>
    public void Cancel()
    {
        IsCancelled = true;
    }
}