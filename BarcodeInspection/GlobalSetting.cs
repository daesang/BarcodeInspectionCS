using BarcodeInspection.Models;
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

        public string Wareky { get; set; }

        public GlobalSetting()
        {
#if DEBUG
            DefaultEndpoint = "http://172.34.34.144:8080"; //로컬은 8080사용
            //DefaultEndpoint = "http://192.168.29.4"; //내부에서 접속
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
        public string MobileVerifyTokenEndpoint { get; set; }
        public string MobileGetEndpoint { get; set; }
        public string MobileGetWarehouseEndpoint { get; set; }
        public string MobileSetEndpoint { get; set; }

        private void UpdateEndpoint(string baseEndpoint)
        {
            MOBILEEndpoint = $"{baseEndpoint}/xamarin";
            MobileAuthEndpoint = $"{baseEndpoint}/xamarin/AuthorizationServer";
            MobileVerifyTokenEndpoint = $"{baseEndpoint}/xamarin/AuthorizationClientVerifyToken";
            MobileGetEndpoint = $"{baseEndpoint}/xamarin/GetServlet";
            MobileGetWarehouseEndpoint = $"{baseEndpoint}/xamarin/GetWarehouseServlet";
            MobileSetEndpoint = $"{baseEndpoint}/xamarin/SetServletForJSON";
        }
    }
}
