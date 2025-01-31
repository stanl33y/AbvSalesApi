using MediatR;
using Ambev.DeveloperEvaluation.Application.Sales.Commands;
using Ambev.DeveloperEvaluation.Domain.Repositories;

namespace Ambev.DeveloperEvaluation.Application.Sales.Handlers;

public class CancelSaleHandler : IRequestHandler<CancelSaleCommand, bool>
{
    private readonly ISaleRepository _saleRepository;

    public CancelSaleHandler(ISaleRepository saleRepository)
    {
        _saleRepository = saleRepository;
    }

    public async Task<bool> Handle(CancelSaleCommand request, CancellationToken cancellationToken)
    {
        var sale = await _saleRepository.GetByIdAsync(request.SaleId, cancellationToken);

        if (sale == null)
            return false;

        sale.Cancel();
        await _saleRepository.UpdateAsync(sale, cancellationToken);

        // Log the SaleCancelled event
        Console.WriteLine($"SaleCancelled: Sale {sale.Id} was cancelled.");

        return true;
    }
}