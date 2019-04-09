namespace Shared.Enumerations
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Reflection;

  /// <summary>
  /// a base class for creating Enumerations.
  /// https://gist.github.com/slovely/1076365
  /// https://lostechies.com/jimmybogard/2008/08/12/enumeration-classes/
  /// </summary>
  public abstract class Enumeration : IComparable
  {
    protected Enumeration() { }

    protected Enumeration(int aValue, string aName, List<string> aAlternateCodes = null)
    {
      Value = aValue;
      Name = aName;
      AlternateCodes = aAlternateCodes ?? new List<string>();
    }

    public List<string> AlternateCodes { get; }
    public string Name { get; }

    public int Value { get; }

    /// <summary>
    /// Get the EnumerationItem form an alternate code.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="aAlternateCode"></param>
    /// <returns></returns>
    public static T FromAlternateCode<T>(string aAlternateCode) where T : Enumeration
    {
      T matchingItem = Parse<T, string>(aAlternateCode, "alternate code", item => item.AlternateCodes.Contains(aAlternateCode));
      return matchingItem;
    }

    /// <summary>
    /// Get the EnumerationItem from  its Name
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="aName"></param>
    /// <returns></returns>
    public static T FromName<T>(string aName) where T : Enumeration
    {
      T matchingItem = Parse<T, string>(aName, "name", item => item.Name == aName);
      return matchingItem;
    }

    /// <summary>
    /// Get the EnumerationItem form a Disaply name, alternate code or value.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="aAlternateCode"></param>
    /// <returns></returns>
    public static T FromString<T>(string aString) where T : Enumeration
    {
      T matchingItem = Parse<T, string>(aString, "", item =>
      item.Name == aString ||
      item.AlternateCodes.Contains(aString)
      );
      return matchingItem;
    }

    /// <summary>
    /// Get the EnumerationItem from is value
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="aValue"></param>
    /// <returns></returns>
    public static T FromValue<T>(int aValue) where T : Enumeration
    {
      T matchingItem = Parse<T, int>(aValue, "value", item => item.Value == aValue);
      return matchingItem;
    }

    public static IEnumerable<T> GetAll<T>() where T : Enumeration
    {
      Type type = typeof(T);
      FieldInfo[] fields = type.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly);

      return fields.Select(info => info.GetValue(null)).OfType<T>();
    }

    public int CompareTo(object other) => Value.CompareTo(((Enumeration)other).Value);

    public override bool Equals(object aObject)
    {
      var otherValue = aObject as Enumeration;

      if (otherValue == null)
      {
        return false;
      }

      bool typeMatches = GetType().Equals(aObject.GetType());
      bool valueMatches = Value.Equals(otherValue.Value);

      return typeMatches && valueMatches;
    }

    public override int GetHashCode() => Value.GetHashCode();

    public override string ToString() => Name;

    protected static T Parse<T, K>(K aValue, string aDescription, Func<T, bool> aPredicate) where T : Enumeration
    {
      T matchingItem = GetAll<T>().FirstOrDefault(aPredicate);

      if (matchingItem == null)
      {
        string message = $"'{aValue}' is not a valid {aDescription} in {typeof(T)}";
        throw new Exception(message);
      }

      return matchingItem;
    }
  }
}