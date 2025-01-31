using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.Commands
{
    /// <summary>
    /// Command for updating an existing sale.
    /// </summary>
    public class UpdateSaleCommand : IRequest<bool>
    {
        /// <summary>
        /// Gets or sets the unique identifier of the sale to update.
        /// </summary>
        public Guid SaleId { get; set; }

        /// <summary>
        /// Gets or sets the updated sale number.
        /// </summary>
        public string SaleNumber { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the updated date and time of the sale.
        /// </summary>
        public DateTime SaleDate { get; set; }

        // Additional fields like CustomerId, BranchId, Items could be added here
    }
}