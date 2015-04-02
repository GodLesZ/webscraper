using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace GodLesZ.Tools.WebScraper.Library
{
  [ComVisible(false)]
  [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
  [Guid("79EAC9D0-BAF9-11CE-8C82-00AA004BA90B")]
  [ComImport]
  public interface IAuthenticate
  {
    [MethodImpl(MethodImplOptions.PreserveSig)]
    [return: MarshalAs(UnmanagedType.I4)]
    int Authenticate(ref IntPtr phwnd, ref IntPtr pszUsername, ref IntPtr pszPassword);
  }
}
