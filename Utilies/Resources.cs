// Decompiled with JetBrains decompiler
// Type: Saruman.Properties.Resources
// Assembly: Anubis Stealer, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4CC1199D-65A9-4D34-AA4B-98216B1632A3
// Assembly location: C:\Users\Administrator\Downloads\Build.exe

using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace Saruman.Properties
{
  [GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
  [DebuggerNonUserCode]
  [CompilerGenerated]
  internal class Resources
  {
    private static ResourceManager resourceMan;
    private static CultureInfo resourceCulture;

    internal Resources()
    {
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static ResourceManager ResourceManager
    {
      get
      {
        if (Resources.resourceMan == null)
          Resources.resourceMan = new ResourceManager("Anubis.Properties.Resources", typeof (Resources).Assembly);
        return Resources.resourceMan;
      }
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static CultureInfo Culture
    {
      get =>Resources.resourceCulture;
      set => Resources.resourceCulture = value;
    }

    internal static string Domains => Resources.ResourceManager.GetString(nameof (Domains), Resources.resourceCulture);
  }
}
