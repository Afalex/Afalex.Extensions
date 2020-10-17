using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using Afalex.Extensions.Internal;

namespace Afalex.Extensions.Tests
{
    public static class ModelOvverider
    {
        public static T Ovveride<T>(T forOvveride, in T newValuesObject)
        {
            ExtractPropertyWithNotNullValues(newValuesObject).ForAll(v => v.Key.SetValue(forOvveride, v.Value));
            return forOvveride;
        }
        private static Dictionary<PropertyInfo, object> ExtractPropertyWithNotNullValues<T>(in T obj)
        {
            var properties = typeof(T).GetProperties();
            Dictionary<PropertyInfo, object> notNullValues = new Dictionary<PropertyInfo, object>();
            foreach (var prop in properties)
            {
                object value = null;
                if ((value = prop.GetValue(obj)) != null)
                    notNullValues.Add(prop, value);
            }
            return notNullValues;
        }
    }
}
