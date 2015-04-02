using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace GodLesZ.Tools.WebScraper.Library
{
  [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
  [Guid("00000112-0000-0000-C000-000000000046")]
  [ComImport]
  public interface IOleObject
  {
    int SetClientSite(IOleClientSite pClientSite);

    void GetClientSite(IOleClientSite ppClientSite);

    void SetHostNames(object szContainerApp, object szContainerObj);

    void Close(uint dwSaveOption);

    void SetMoniker(uint dwWhichMoniker, object pmk);

    void GetMoniker(uint dwAssign, uint dwWhichMoniker, object ppmk);

    void InitFromData(IDataObject pDataObject, bool fCreation, uint dwReserved);

    void GetClipboardData(uint dwReserved, IDataObject ppDataObject);

    void DoVerb(uint iVerb, uint lpmsg, object pActiveSite, uint lindex, uint hwndParent, uint lprcPosRect);

    void EnumVerbs(object ppEnumOleVerb);

    void Update();

    void IsUpToDate();

    void GetUserClassID(uint pClsid);

    void GetUserType(uint dwFormOfType, uint pszUserType);

    void SetExtent(uint dwDrawAspect, uint psizel);

    void GetExtent(uint dwDrawAspect, uint psizel);

    void Advise(object pAdvSink, uint pdwConnection);

    void Unadvise(uint dwConnection);

    void EnumAdvise(object ppenumAdvise);

    void GetMiscStatus(uint dwAspect, uint pdwStatus);

    void SetColorScheme(object pLogpal);
  }
}
