using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace CrossCutting.EnumExtensions
{
    public static class TupleEnumExtensions
    {
        public static string GetDescription(this Enum value)
        {
            var (_, _, descr) = value.ConvertToEnumTuple();
            return descr;
        }

        public static (int Id, string Name, string Descr) ConvertToEnumTuple<T>(this T value) where T : struct
        {
            if (!typeof(T).IsEnum)
            {
                throw new ApplicationException($"{typeof(T)} must be enum");
            }

            return (Enum.Parse(typeof(T), value.ToString()) as Enum).ConvertToEnumTuple();
        }

        public static (int Id, string Name, string Descr) ConvertToEnumTuple(this Enum value)
        {
            try
            {
                FieldInfo fi = value.GetType().GetField(value.ToString());

                DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

                var id = Convert.ToInt32(value);
                var name = value.ToString();
                var descr = attributes != null && attributes.Length > 0 ? attributes[0].Description : name;

                return (id, name, descr);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Unable to convert from Enum to EnumModel", ex);
            }
        }

        public static List<(int Id, string Name, string Descr)> ConvertToEnumTupleList<T>() where T : struct
        {
            if (!typeof(T).IsEnum)
            {
                throw new ApplicationException($"{typeof(T)} must be enum");
            }

            var result = new List<(int, string, string)>();

            foreach (var value in Enum.GetValues(typeof(T)))
            {
                result.Add(((Enum)value).ConvertToEnumTuple());
            }

            return result;
        }
    }
}
