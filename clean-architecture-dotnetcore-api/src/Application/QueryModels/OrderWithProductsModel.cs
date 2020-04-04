using AutoMapper;
using CrossCutting.Automapper.Base;
using CrossCutting.Automapper.MemberValueResolvers;
using CrossCutting.EnumExtensions;
using Domain.Entities;
using Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Application.QueryModels
{
    public class OrderWithProductsModel : IMapFrom<Order>
    {
        public Guid Id { get; set; }
        public DateTime DateCreated { get; set; }
        public EnumModel Status { get; set; }
        public double Sum { get; set; }
        public List<ProductLineItemModel> Products { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Order, OrderWithProductsModel>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(new EnumValueResolver<OrderStatus>(), src => src.OrderStatus))
                .ForMember(dest => dest.Sum, opt => opt.MapFrom(src => src.ProductLineItems.Sum(pli => pli.Quantity * pli.Product.Price)))
                .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.ProductLineItems))
                ;
        }
    }
}
