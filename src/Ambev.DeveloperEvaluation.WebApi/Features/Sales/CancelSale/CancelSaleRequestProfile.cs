using Ambev.DeveloperEvaluation.Application.Sales.Commands;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.CancelSale;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Mappings
{
    public class CancelSaleRequestProfile : Profile
    {
        public CancelSaleRequestProfile()
        {
            CreateMap<CancelSaleRequest, CancelSaleCommand>();
        }
    }
}