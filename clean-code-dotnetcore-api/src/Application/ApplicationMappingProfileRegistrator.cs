using CrossCutting.Automapper;
using System.Reflection;

namespace Application
{
    public class ApplicationMappingProfileRegistrator : BaseMappingProfile
    {
        public override Assembly Assembly => typeof(ApplicationModule).Assembly;
    }
}
