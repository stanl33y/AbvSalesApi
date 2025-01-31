namespace Ambev.DeveloperEvaluation.Application.Sales.Results
{
    /// <summary>
    /// Represents the response returned after successfully creating a new sale.
    /// </summary>
    public class CreateSaleResult
    {
        /// <summary>
        /// Gets or sets the unique identifier of the newly created sale.
        /// </summary>
        public Guid Id { get; set; }
    }
}