using CrossCutting.Automapper.Base;
using System.Reflection;

namespace CrossCutting.Automapper
{
    public class CrossCuttingAutomapperMappingProfileRegistrator : BaseMappingProfile
    {
        public override Assembly Assembly => typeof(CrossCuttingAutomapperModule).Assembly;
    }
}
