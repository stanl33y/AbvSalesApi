using Ambev.DeveloperEvaluation.Application.Sales.GetSale;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Mappings
{
    public class GetSaleResponseProfile : Profile
    {
        public GetSaleResponseProfile()
        {
            CreateMap<Sale, GetSaleResponse>();
            CreateMap<SaleItem, SaleItemResponse>();
            CreateMap<GetSaleResult, GetSaleResponse>();
        }
    }
}