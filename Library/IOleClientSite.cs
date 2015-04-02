using System.Runtime.InteropServices;

namespace GodLesZ.Tools.WebScraper.Library
{
  [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
  [Guid("00000118-0000-0000-C000-000000000046")]
  [ComImport]
  public interface IOleClientSite
  {
    void SaveObject();

    void GetMoniker(uint dwAssign, uint dwWhichMoniker, object ppmk);

    void GetContainer(object ppContainer);

    void ShowObject();

    void OnShowWindow(bool fShow);

    void RequestNewObjectLayout();
  }
}
