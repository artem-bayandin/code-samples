using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace CrossCutting.FluentValidation
{
    public static class ValidatorMessageExtensions
    {
        public static IRuleBuilderOptions<T, TProperty> WithMessage<T, TProperty, TError>(this IRuleBuilderOptions<T, TProperty> rule
            , TError errorMessage
            , params object[] args
            ) where TError : struct
        {
            var (id, name, descr) = errorMessage.ConvertToEnumModel();

            // choose what to send back here
            // currently: formatted description
            // if just 'code' needed : replace 'descr' with 'name' (name don't contain any {})
            var formatter = descr;

            var message = FormatMessage(formatter, args);
            return rule.WithMessage(FormatMessage(formatter, args));
        }

        public static string FormatMessage(Enum value, params object[] args) => FormatMessage(value.GetDescription(), args);

        private static string FormatMessage(string formatter, params object[] args) => String.Format(formatter, args);
    }

    // TODO: refactor, as it is a copy of EnumExtensions from CrossCutting.Automapper
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum value)
        {
            var (_, _, descr) = value.ConvertToEnumModel();
            return descr;
        }

        public static (int, string, string) ConvertToEnumModel<T>(this T value) where T : struct
        {
            if (!typeof(T).IsEnum)
            {
                throw new ApplicationException($"{typeof(T)} must be enum");
            }

            return (Enum.Parse(typeof(T), value.ToString()) as Enum).ConvertToEnumModel();
        }

        public static (int, string, string) ConvertToEnumModel(this Enum value)
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

        public static List<(int, string, string)> ConvertToList<T>() where T : struct
        {
            if (!typeof(T).IsEnum)
            {
                throw new ApplicationException($"{typeof(T)} must be enum");
            }

            var result = new List<(int, string, string)>();

            foreach (var value in Enum.GetValues(typeof(T)))
            {
                result.Add(((Enum)value).ConvertToEnumModel());
            }

            return result;
        }
    }
}
