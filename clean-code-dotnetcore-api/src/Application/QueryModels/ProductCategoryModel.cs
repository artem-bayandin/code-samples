using Application.Mappings;
using Domain.Entities;
using System;

namespace Application.QueryModels
{
    public class ProductCategoryModel : IMapFrom<ProductCategory>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        
        //// for difficult mappings
        //public void Mapping(Profile profile)
        //{
        //    profile.CreateMap<ProductCategory, ProductCategoryModel>()
        //        .ForMember(m => m.Id, opt => opt.MapFrom(x => x.Id))
        //        .ForMember(m => m.Name, opt => opt.MapFrom(x => x.Name))
        //        ;
        //}
    }
}
