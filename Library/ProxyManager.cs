using System;
using System.Net;
using System.Net.Cache;
using System.Runtime.InteropServices;
using System.Text;
using System.Timers;
using GodLesZ.Tools.WebScraper.Forms;
using GodLesZ.Tools.WebScraper.Properties;

namespace GodLesZ.Tools.WebScraper.Library {
    internal class ProxyManager : IOleClientSite, IServiceProvider, IAuthenticate {

        [DllImport("wininet.dll", SetLastError = true)]
        private static extern bool InternetSetOption(IntPtr hInternet, int dwOption, IntPtr lpBuffer, int lpdwBufferLength);
        
        private readonly Guid _iidIAuthenticate = new Guid("79eac9d0-baf9-11ce-8c82-00aa004ba90b");
        private Timer _proxyTimer;
        private int _proxyIndex;
        private string _username;
        private string _password;

        public bool AuthRequired {
            get;
            private set;

        }

        public string AuthHeader {
            get { return GetAuthHeader(); }
        }

        public bool Active {
            get;
            private set;

        }


        public void SaveObject() {
        }

        public void GetMoniker(uint dwAssign, uint dwWhichMoniker, object ppmk) {
        }

        public void GetContainer(object ppContainer) {
            if (ppContainer == null) {
                throw new ArgumentNullException("ppContainer");
            }

            ppContainer = this;
        }

        public void ShowObject() {
        }

        public void OnShowWindow(bool fShow) {
        }

        public void RequestNewObjectLayout() {
        }

        public int QueryService(ref Guid guidService, ref Guid riid, out IntPtr ppvObject) {
            if (guidService.CompareTo(_iidIAuthenticate) == 0 && riid.CompareTo(_iidIAuthenticate) == 0) {
                ppvObject = Marshal.GetComInterfaceForObject(this, typeof(IAuthenticate));
                return 0;
            }

            ppvObject = new IntPtr();
            return -2146697199;
        }

        public int Authenticate(ref IntPtr phwnd, ref IntPtr pszUsername, ref IntPtr pszPassword) {
            if (!AuthRequired) {
                return 0;
            }

            var num1 = Marshal.StringToCoTaskMemAuto(_username);
            var num2 = Marshal.StringToCoTaskMemAuto(_password);
            pszUsername = num1;
            pszPassword = num2;
            return 0;
        }

        private string GetAuthHeader() {
            string str = null;
            if (AuthRequired)
                str = string.Format("Proxy-Authorization: Basic {0}{1}", Convert.ToBase64String(Encoding.UTF8.GetBytes(_username + ":" + _password)), Environment.NewLine);
            return str;
        }

        public void SetCredentials() {
            if (!AuthRequired)
                return;
            InternetSetOption(IntPtr.Zero, 43, Marshal.StringToHGlobalAnsi(_username), _username.Length + 1);
            InternetSetOption(IntPtr.Zero, 44, Marshal.StringToHGlobalAnsi(_password), _password.Length + 1);
            InternetSetOption(IntPtr.Zero, 39, IntPtr.Zero, 0);
            InternetSetOption(IntPtr.Zero, 37, IntPtr.Zero, 0);
        }

        private bool SetProxy(ProxyData proxyData) {
            var flag = false;
            try {
                if (CheckProxy(proxyData)) {
                    InternetProxyInfo internetProxyInfo;
                    internetProxyInfo.DwAcccessType = 3;
                    internetProxyInfo.Proxy = Marshal.StringToHGlobalAnsi(proxyData.Address);
                    internetProxyInfo.ProxyBypass = Marshal.StringToHGlobalAnsi("local");
                    var num = Marshal.AllocCoTaskMem(Marshal.SizeOf((object)internetProxyInfo));
                    Marshal.StructureToPtr((object)internetProxyInfo, num, true);
                    flag = InternetSetOption(IntPtr.Zero, 38, num, Marshal.SizeOf((object)internetProxyInfo));
                    if (proxyData.Username != null && proxyData.Password != null) {
                        AuthRequired = true;
                        _username = proxyData.Username;
                        _password = proxyData.Password;
                    } else
                        AuthRequired = false;
                    InternetSetOption(IntPtr.Zero, 39, IntPtr.Zero, 0);
                    InternetSetOption(IntPtr.Zero, 37, IntPtr.Zero, 0);
                }
            } catch (Exception) {
            }
            return flag;
        }

        private void ClearProxy() {
            var internetProxyInfo = new InternetProxyInfo();
            try {
                internetProxyInfo.DwAcccessType = 1;
                var num = Marshal.AllocCoTaskMem(Marshal.SizeOf((object)internetProxyInfo));
                Marshal.StructureToPtr((object)internetProxyInfo, num, true);
                InternetSetOption(IntPtr.Zero, 38, num, Marshal.SizeOf((object)internetProxyInfo));
            } catch (Exception) {
            }
        }

        public void Start() {
            if (!Settings.Default.ProxyEnabled || Active)
                return;
            if (!Settings.Default.ProxyRotate) {
                SetProxy(SettingsForm.GetProxyData((string)Settings.Default.ProxyDataList[0]));
            } else {
                _proxyTimer = new Timer();
                _proxyTimer.Elapsed += proxyTimer_Elapsed;
                _proxyTimer.Interval = Settings.Default.ProxyRotateInterval * 60 * 1000;
                proxyTimer_Elapsed(this, null);
                _proxyTimer.Start();
            }
            Active = true;
        }

        private void proxyTimer_Elapsed(object sender, ElapsedEventArgs e) {
            var flag = false;
            var proxyDataList = Settings.Default.ProxyDataList;
            var index = _proxyIndex;
            do {
                if (SetProxy(SettingsForm.GetProxyData((string)proxyDataList[index])))
                    flag = true;
                ++index;
                if (index >= proxyDataList.Count)
                    index = 0;
                if (flag) {
                    _proxyIndex = index;
                    break;
                }
                if (index != _proxyIndex) {
                    continue;
                }

                stop();
                break;
            }
            while (!flag);
        }

        public void stop() {
            if (!Settings.Default.ProxyEnabled || !Active)
                return;
            if (Settings.Default.ProxyRotate)
                _proxyTimer.Stop();
            ClearProxy();
            Active = false;
        }

        public static bool CheckProxy(ProxyData proxyData) {
            return 
                !CheckProxy(proxyData, "http://www.microsoft.com") && 
                !CheckProxy(proxyData, "http://www.w3.org") && 
                !CheckProxy(proxyData, "http://www.yahoo.com");
        }

        private static bool CheckProxy(ProxyData proxyData, string website) {
            var flag = false;
            HttpWebResponse httpWebResponse = null;
            try {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(website);
                var webProxy = new WebProxy();
                webProxy.Address = new Uri(proxyData.Address);
                if (proxyData.Username != null) {
                    webProxy.Credentials = new NetworkCredential(proxyData.Username, proxyData.Password);
                    webProxy.BypassProxyOnLocal = true;
                }
                httpWebRequest.Proxy = webProxy;
                httpWebRequest.Timeout = 10000;
                httpWebRequest.CachePolicy = new HttpRequestCachePolicy(HttpRequestCacheLevel.NoCacheNoStore);
                httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                flag = httpWebResponse.StatusCode == HttpStatusCode.OK;
                httpWebResponse.Close();
            } catch (Exception ex) {
                Console.Write(ex.Message);
                if (httpWebResponse != null)
                    httpWebResponse.Close();
            }
            return flag;
        }

    }

}
