using AutoMapper;
using CrossCutting.Automapper;
using Domain.Entities;
using System;

namespace Application.QueryModels
{
    public class ProductLineItemModel : IMapFrom<ProductLineItem>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public double Sum { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ProductLineItem, ProductLineItemModel>()
                .ForMember(m => m.Id, opt => opt.MapFrom(x => x.ProductId))
                .ForMember(m => m.Name, opt => opt.MapFrom(x => x.Product.Name))
                .ForMember(m => m.Description, opt => opt.MapFrom(x => x.Product.Description))
                .ForMember(m => m.Price, opt => opt.MapFrom(x => x.Product.Price))
                .ForMember(m => m.Quantity, opt => opt.MapFrom(x => x.Quantity))
                .ForMember(m => m.Sum, opt => opt.MapFrom(x => x.Quantity * x.Product.Price))
                ;
        }
    }
}
