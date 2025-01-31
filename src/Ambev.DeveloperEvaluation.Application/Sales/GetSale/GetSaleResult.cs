namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale
{
    /// <summary>
    /// Response model forGetSale operation.
    /// </summary>
    public class GetSaleResult
    {
        /// <summary>
        /// The unique identifier of the sale.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The unique sale number.
        /// </summary>
        public string SaleNumber { get; set; } = string.Empty;

        /// <summary>
        /// The date and time when the sale was made.
        /// </summary>
        public DateTime SaleDate { get; set; }

        public Guid CustomerId { get; set; }
        public decimal TotalAmount { get; set; }
        public Guid BranchId { get; set; }
        public bool IsCancelled { get; set; }
    }
}