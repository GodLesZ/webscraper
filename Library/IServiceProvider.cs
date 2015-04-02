using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace GodLesZ.Tools.WebScraper.Library
{
  [Guid("6d5140c1-7436-11ce-8034-00aa006009fa")]
  [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
  [ComVisible(false)]
  [ComImport]
  public interface IServiceProvider
  {
    [MethodImpl(MethodImplOptions.PreserveSig)]
    [return: MarshalAs(UnmanagedType.I4)]
    int QueryService(ref Guid guidService, ref Guid riid, out IntPtr ppvObject);
  }
}
