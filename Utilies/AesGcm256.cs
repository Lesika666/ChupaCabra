// Decompiled with JetBrains decompiler
// Type: Anubis.AesGcm256
// Assembly: Anubis Stealer, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4CC1199D-65A9-4D34-AA4B-98216B1632A3
// Assembly location: C:\Users\Administrator\Downloads\Build.exe

using System.Text;

namespace Anubis
{
  public static class AesGcm256
  {
    public static string Decrypt(byte[] encryptedBytes, byte[] key, byte[] iv)
    {
      string empty = string.Empty;
      try
      {
        GcmBlockCipher gcmBlockCipher = new GcmBlockCipher((IBlockCipher) new AesFastEngine());
        gcmBlockCipher.Init(false, (ICipherParameters) new AeadParameters(new KeyParameter(key), 128, iv, (byte[]) null));
        byte[] numArray = new byte[gcmBlockCipher.GetOutputSize(encryptedBytes.Length)];
        int outOff = gcmBlockCipher.ProcessBytes(encryptedBytes, 0, encryptedBytes.Length, numArray, 0);
        gcmBlockCipher.DoFinal(numArray, outOff);
        return Encoding.UTF8.GetString(numArray).TrimEnd("\r\n\0".ToCharArray());
      }
      catch
      {
        return empty;
      }
    }
  }
}
