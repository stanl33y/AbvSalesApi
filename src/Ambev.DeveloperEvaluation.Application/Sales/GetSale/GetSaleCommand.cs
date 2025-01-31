using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale
{
    /// <summary>
    /// Command for retrieving a sale by its ID.
    /// </summary>
    public class GetSaleCommand : IRequest<GetSaleResult>
    {
        /// <summary>
        /// The unique identifier of the sale to retrieve.
        /// </summary>
        public Guid SaleId { get; }

        /// <summary>
        /// Initializes a new instance of GetSaleCommand.
        /// </summary>
        /// <param name="saleId">The ID of the sale to retrieve.</param>
        public GetSaleCommand(Guid saleId)
        {
            SaleId = saleId;
        }
    }
}