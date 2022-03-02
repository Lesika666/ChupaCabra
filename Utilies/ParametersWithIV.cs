// Decompiled with JetBrains decompiler
// Type: Anubis.ParametersWithIV
// Assembly: Anubis Stealer, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4CC1199D-65A9-4D34-AA4B-98216B1632A3
// Assembly location: C:\Users\Administrator\Downloads\Build.exe

using System;

namespace Anubis
{
  public class ParametersWithIV : ICipherParameters
  {
    private readonly ICipherParameters parameters;
    private readonly byte[] iv;

    public ICipherParameters Parameters => this.parameters;

    public ParametersWithIV(ICipherParameters parameters, byte[] iv)
      : this(parameters, iv, 0, iv.Length)
    {
    }

    public ParametersWithIV(ICipherParameters parameters, byte[] iv, int ivOff, int ivLen)
    {
      if (parameters == null)
        throw new ArgumentNullException(nameof (parameters));
      if (iv == null)
        throw new ArgumentNullException(nameof (iv));
      this.parameters = parameters;
      this.iv = new byte[ivLen];
      Array.Copy((Array) iv, ivOff, (Array) this.iv, 0, ivLen);
    }

    public byte[] GetIV() => (byte[]) this.iv.Clone();
  }
}
