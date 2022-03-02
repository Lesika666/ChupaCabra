// Decompiled with JetBrains decompiler
// Type: Anubis.KeyParameter
// Assembly: Anubis Stealer, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4CC1199D-65A9-4D34-AA4B-98216B1632A3
// Assembly location: C:\Users\Administrator\Downloads\Build.exe

using System;

namespace Anubis
{
  public class KeyParameter : ICipherParameters
  {
    private readonly byte[] key;

    public KeyParameter(byte[] key) => this.key = key != null ? (byte[]) key.Clone() : throw new ArgumentNullException(nameof (key));

    public KeyParameter(byte[] key, int keyOff, int keyLen)
    {
      if (key == null)
        throw new ArgumentNullException(nameof (key));
      if (keyOff < 0 || keyOff > key.Length)
        throw new ArgumentOutOfRangeException(nameof (keyOff));
      if (keyLen < 0 || keyOff + keyLen > key.Length)
        throw new ArgumentOutOfRangeException(nameof (keyLen));
      this.key = new byte[keyLen];
      Array.Copy((Array) key, keyOff, (Array) this.key, 0, keyLen);
    }

    public byte[] GetKey() => (byte[]) this.key.Clone();
  }
}
