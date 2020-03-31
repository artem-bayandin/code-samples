using CrossCutting.Automapper.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace CrossCutting.Automapper.Extensions
{
	public static class EnumExtensions
	{
		public static EnumModel ConvertToEnumModel(this Enum value)
		{
			try
			{
				FieldInfo fi = value.GetType().GetField(value.ToString());

				DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

				var id = Convert.ToInt32(value);
				var name = value.ToString();
				var descr = attributes != null && attributes.Length > 0 ? attributes[0].Description : name;

				return new EnumModel(id, name, descr);
			}
			catch (Exception ex)
			{
				throw new ApplicationException("Unable to convert from Enum to EnumModel", ex);
			}
		}

		public static List<EnumModel> ConvertToList<T>() where T : struct
		{
			if (!typeof(T).IsEnum)
			{
				throw new ApplicationException($"{typeof(T)} must be enum");
			}

			var result = new List<EnumModel>();

			foreach (var value in Enum.GetValues(typeof(T)))
			{
				result.Add(((Enum)value).ConvertToEnumModel());
			}

			return result;
		}
	}
}
