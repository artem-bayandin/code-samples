using AutoMapper;
using CrossCutting.Automapper.Base;
using CrossCutting.Automapper.MemberValueResolvers;
using CrossCutting.EnumExtensions;
using Domain.Entities;
using Domain.Entities.Enums;
using System;
using System.Linq;

namespace Application.QueryModels
{
    public class OrderModel : IMapFrom<Order>
    {
        public Guid Id { get; set; }
        public DateTime DateCreated { get; set; }
        public EnumModel Status { get; set; }
        public double Sum { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Order, OrderModel>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(new EnumValueResolver<OrderStatus>(), src => src.OrderStatus))
                .ForMember(dest => dest.Sum, opt => opt.MapFrom(src => src.ProductLineItems.Sum(pli => pli.Quantity * pli.Product.Price)))
                ;
        }
    }
}
