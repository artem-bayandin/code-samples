using AutoMapper;
using CrossCutting.Automapper.Base;
using CrossCutting.Automapper.MemberValueResolvers;
using CrossCutting.Automapper.Models;
using Domain.Entities;
using Domain.Enums;
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
                // TODO: fix
                //.ForMember(dest => dest.Status, opt => opt.MapFrom<EnumValueResolver<OrderStatus>, OrderStatus>(src => src.OrderStatus))
                .ForMember(dest => dest.Status, opt => opt.Ignore())
                .ForMember(dest => dest.Sum, opt => opt.MapFrom(src => src.ProductLineItems.Sum(pli => pli.Quantity * pli.Product.Price)))
                ;
        }
    }
}
