using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.Commands
{
    /// <summary>
    /// Command for canceling a sale.
    /// </summary>
    public class CancelSaleCommand : IRequest<bool>
    {
        /// <summary>
        /// Gets or sets the unique identifier of the sale to cancel.
        /// </summary>
        public Guid SaleId { get; set; }
    }
}