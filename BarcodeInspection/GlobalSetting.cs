using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarcodeInspection
{
    public class GlobalSetting
    {
        //GITHUB테스트
        //git서버에 반영하려면 Command & Push
        private string DefaultEndpoint = "http://barcode.daesangit.com";

        private string _baseEndpoint = string.Empty;
        private static readonly GlobalSetting _instance = new GlobalSetting();

        public GlobalSetting()
        {
#if DEBUG
            //DefaultEndpoint = "http://127.0.0.1:8080";
            DefaultEndpoint = "http://barcode.daesangit.com";
#endif
            //AuthToken = Microsoft.Win32.Registry.GetValue("HKEY_CURRENT_USER\\Software\\BarcodeInspection", "AuthToken", string.Empty).ToString();
            BaseEndpoint = DefaultEndpoint;
        }

        public static GlobalSetting Instance
        {
            get { return _instance; }
        }

        public string BaseEndpoint
        {
            get { return _baseEndpoint; }
            set
            {
                _baseEndpoint = value;
                UpdateEndpoint(_baseEndpoint);
            }
        }
        public string AuthToken { get; set; }

        public string ClientId { get { return "BarcodeInspection"; } }


        public string MOBILEEndpoint { get; set; }
        public string MobileAuthEndpoint { get; set; }
        public string MobileGetEndpoint { get; set; }
        public string MobileSetEndpoint { get; set; }

        private void UpdateEndpoint(string baseEndpoint)
        {
            MOBILEEndpoint = $"{baseEndpoint}/xamarin";
            MobileAuthEndpoint = $"{baseEndpoint}/xamarin/AuthorizationServer";
            MobileGetEndpoint = $"{baseEndpoint}/xamarin/GetServlet";
            MobileSetEndpoint = $"{baseEndpoint}/xamarin/SetServletForJSON";
        }
    }
}
