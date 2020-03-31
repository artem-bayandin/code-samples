using AutoMapper;
using System;
using System.Linq;
using System.Reflection;

namespace CrossCutting.Automapper
{
    public abstract class BaseMappingProfile : Profile
    {
        public BaseMappingProfile()
        {
            ApplyMappingsFromAssembly(Assembly);
        }

        public abstract Assembly Assembly { get; }

        private void ApplyMappingsFromAssembly(Assembly assembly)
        {
            var types = assembly
                .GetExportedTypes()
                .Where(t => t.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapFrom<>)))
                .ToList();

            foreach (var type in types)
            {
                var instance = Activator.CreateInstance(type);

                var methodInfo = type.GetMethod("Mapping") ?? type.GetInterface("IMapFrom`1").GetMethod("Mapping");

                methodInfo?.Invoke(instance, new object[] { this });
            }
        }
    }
}
