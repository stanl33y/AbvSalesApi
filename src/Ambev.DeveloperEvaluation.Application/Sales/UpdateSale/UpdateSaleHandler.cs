using MediatR;
using Ambev.DeveloperEvaluation.Application.Sales.Commands;
using Ambev.DeveloperEvaluation.Domain.Repositories;

namespace Ambev.DeveloperEvaluation.Application.Sales.Handlers
{
    public class UpdateSaleHandler : IRequestHandler<UpdateSaleCommand, bool>
    {
        private readonly ISaleRepository _saleRepository;

        public UpdateSaleHandler(ISaleRepository saleRepository)
        {
            _saleRepository = saleRepository;
        }

        public async Task<bool> Handle(UpdateSaleCommand request, CancellationToken cancellationToken)
        {
            var sale = await _saleRepository.GetByIdAsync(request.SaleId, cancellationToken);
            if (sale == null)
                return false;

            sale.SaleNumber = request.SaleNumber;
            sale.SaleDate = request.SaleDate;


            // Log the SaleUpdated event
            Console.WriteLine($"SaleUpdated: Sale {sale.Id}");

            await _saleRepository.UpdateAsync(sale, cancellationToken);
            return true;
        }
    }
}