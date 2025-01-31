using MediatR;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Application.Sales.Commands;

namespace Ambev.DeveloperEvaluation.Application.Sales.Handlers;

public class CreateSaleHandler : IRequestHandler<CreateSaleCommand, Sale>
{
    private readonly ISaleRepository _saleRepository;

    public CreateSaleHandler(ISaleRepository saleRepository)
    {
        _saleRepository = saleRepository;
    }

    public async Task<Sale> Handle(CreateSaleCommand request, CancellationToken cancellationToken)
    {
        var sale = new Sale(
            request.SaleNumber,
            request.SaleDate,
            request.CustomerId,
            request.BranchId,
            request.Items.Select(item => new SaleItem(item.ProductId, item.Quantity, item.UnitPrice)).ToList()
        );

        await _saleRepository.CreateAsync(sale, cancellationToken);

        // Log the SaleCreated event
        Console.WriteLine($"SaleCreated: Sale {sale.Id} was created.");

        return sale;
    }
}