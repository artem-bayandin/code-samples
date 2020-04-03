using CrossCutting.EnumExtensions;
using FluentValidation;
using System;

namespace CrossCutting.FluentValidation
{
    public static class ValidatorMessageExtensions
    {
        public static IRuleBuilderOptions<T, TProperty> WithMessage<T, TProperty, TError>(this IRuleBuilderOptions<T, TProperty> rule
            , TError errorMessage
            , params object[] args
            ) where TError : struct
        {
            var (id, name, descr) = errorMessage.ConvertToEnumTuple();

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
}
