using System;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CancelSale
{
    /// <summary>
    /// Represents a request to cancel a sale in the system.
    /// </summary>
    public class CancelSaleRequest
    {
        /// <summary>
        /// Gets or sets the unique identifier of the sale to cancel.
        /// </summary>
        public Guid SaleId { get; set; }
    }
}