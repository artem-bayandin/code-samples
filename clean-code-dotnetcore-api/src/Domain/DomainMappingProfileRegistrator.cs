using CrossCutting.Automapper.Base;
using Domain.Commands.CreateProduct;
using Domain.Entities;
using System;
using System.Reflection;

namespace Domain
{
    public class DomainMappingProfileRegistrator : BaseMappingProfile
    {
        public override Assembly Assembly => typeof(DomainModule).Assembly;

        public DomainMappingProfileRegistrator()
        {
            // register command-to-entity maps
            CreateMap<CreateProductCommand, Product>()
                .AfterMap((cmd, prod) => { prod.Id = Guid.NewGuid(); });
        }
    }
}
