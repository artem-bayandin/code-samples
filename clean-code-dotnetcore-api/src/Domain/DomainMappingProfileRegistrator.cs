using CrossCutting.Automapper;
using System.Reflection;

namespace Domain
{
    public class DomainMappingProfileRegistrator : BaseMappingProfile
    {
        public override Assembly Assembly => typeof(DomainModule).Assembly;
    }
}
