// https://ole.michelsen.dk/blog/serialize-object-into-a-query-string-with-reflection.html
namespace TimeWarp.Extensions
{
  using System;
  using System.Collections;
  using System.Collections.Generic;
  using System.Linq;

  public static class ObjectExtensions
  {
    public static string ToQueryString(this object aObject, string aSeparator = ",")
    {
      if (aObject == null)
        throw new ArgumentNullException("object");

      Dictionary<string, object> properties = GetProperties(aObject);
      List<string> propertyNames = GetEnumerablePropertyNames(properties);
      ConcatEnumerablesToString(aSeparator, properties, propertyNames);
      return ConcatKvpToQueryString(properties);
    }

    /// <summary>
    /// Concat all key/value pairs into a string separated by ampersand
    /// </summary>
    /// <param name="aProperties"></param>
    /// <returns></returns>
    private static string ConcatKvpToQueryString(Dictionary<string, object> aProperties)
    {
      return string.Join("&", aProperties
          .Select(aKeyValuePair => string.Concat(
              Uri.EscapeDataString(aKeyValuePair.Key), "=",
              Uri.EscapeDataString(aKeyValuePair.Value.ToString()))));
    }

    /// <summary>
    /// Concat all IEnumerable properties into a comma separated string
    /// </summary>
    /// <param name="aSeparator"></param>
    /// <param name="properties"></param>
    /// <param name="aPropertyNames"></param>
    private static void ConcatEnumerablesToString(string aSeparator, Dictionary<string, object> aProperties, List<string> aPropertyNames)
    {
      foreach (string key in aPropertyNames)
      {
        Type valueType = aProperties[key].GetType();
        Type valueElemType = valueType.IsGenericType
                                ? valueType.GetGenericArguments()[0]
                                : valueType.GetElementType();
        if (valueElemType.IsPrimitive || valueElemType == typeof(string))
        {
          var enumerable = aProperties[key] as IEnumerable;
          aProperties[key] = string.Join(aSeparator, enumerable.Cast<object>());
        }
      }
    }

    /// <summary>
    /// Get names for all IEnumerable properties (excl. string)
    /// </summary>
    /// <param name="aProperties"></param>
    /// <returns></returns>
    private static List<string> GetEnumerablePropertyNames(Dictionary<string, object> aProperties)
    {
      return aProperties
          .Where(aKeyValuePair => !(aKeyValuePair.Value is string) && aKeyValuePair.Value is IEnumerable)
          .Select(aKeyValuePair => aKeyValuePair.Key)
          .ToList();
    }

    /// <summary>
    /// Get all properties on the object
    /// </summary>
    /// <param name="aObject"></param>
    /// <returns></returns>
    private static Dictionary<string, object> GetProperties(object aObject)
    {
      return aObject.GetType().GetProperties()
          .Where(aPropertyInfo => aPropertyInfo.CanRead)
          .Where(aPropertyInfo => aPropertyInfo.GetValue(aObject, null) != null)
          .ToDictionary(aPropertyInfo => aPropertyInfo.Name, aPropertyInfo => aPropertyInfo.GetValue(aObject, null));
    }
  }
}