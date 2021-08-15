using System;
using System.Collections.Generic;
using System.Linq;

namespace CrossCutting.EnumExtensions
{
    public static class ModelEnumExtensions
    {
        public static EnumModel ConvertToEnumModel(this Enum value)
        {
            var (id, name, descr) = value.ConvertToEnumTuple();
            return new EnumModel(id, name, descr);
        }

        public static List<EnumModel> ConvertToEnumModelList<T>() where T : struct
        {
            var data = TupleEnumExtensions.ConvertToEnumTupleList<T>();
            return data.Select(x => new EnumModel(x.Id, x.Name, x.Descr)).ToList();
        }
    }
}
