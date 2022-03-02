// Decompiled with JetBrains decompiler
// Type: Anubis.IsNullExtension
// Assembly: Anubis Stealer, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4CC1199D-65A9-4D34-AA4B-98216B1632A3
// Assembly location: C:\Users\Administrator\Downloads\Build.exe

using System;

namespace Anubis
{
  public static class IsNullExtension
  {
    public static bool IsNotNull<T>(this T data) => (object) data != null;

    public static string IsNull(this string value, string defaultValue) => !string.IsNullOrEmpty(value) ? value : defaultValue;

    public static bool IsNullOrEmpty(this string str) => string.IsNullOrEmpty(str);

    public static bool IsNull(this bool? value, bool def) => value.HasValue ? value.Value : def;

    public static T IsNull<T>(this T value) where T : class => (object) value == null ? Activator.CreateInstance<T>() : value;

    public static T IsNull<T>(this T value, T def) where T : class
    {
      if ((object) value != null)
        return value;
      return (object) def == null ? Activator.CreateInstance<T>() : def;
    }

    public static int IsNull(this int? value, int def) => value.HasValue ? value.Value : def;

    public static long IsNull(this long? value, long def) => value.HasValue ? value.Value : def;

    public static double IsNull(this double? value, double def) => value.HasValue ? value.Value : def;

    public static DateTime IsNull(this DateTime? value, DateTime def) => value.HasValue ? value.Value : def;

    public static Guid IsNull(this Guid? value, Guid def) => value.HasValue ? value.Value : def;
  }
}
