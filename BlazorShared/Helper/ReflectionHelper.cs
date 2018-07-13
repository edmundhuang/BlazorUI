using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace BlazorShared.Helper
{
    public static class ReflectionHelper
    {
        public static Type GetAnyElementType(this Type type)
        {
            // Type is Array
            // short-circuit if you expect lots of arrays
            if (type.IsArray)
                return type.GetElementType();

            // type is IEnumerable<T>;
            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(IEnumerable<>))
                return type.GetGenericArguments()[0];

            // type implements/extends IEnumerable<T>;
            var enumType = type.GetInterfaces()
                                    .Where(t => t.IsGenericType &&
                                           t.GetGenericTypeDefinition() == typeof(IEnumerable<>))
                                    .Select(t => t.GenericTypeArguments[0]).FirstOrDefault();
            return enumType ?? type;
        }

        public static string GetDisplayName(this PropertyInfo property)
        {
            if (property.IsDefined(typeof(DisplayAttribute)))
            {
                return property.GetCustomAttribute<DisplayAttribute>().Name;
            }
            else
            {
                return property.Name;
            }
        }
    }
}
