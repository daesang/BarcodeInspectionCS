using BarcodeInspection.Helper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BarcodeInspection.Services
{
    public class BaseHttpService
    {
        private static readonly BaseHttpService instance = new BaseHttpService();

        private readonly string GET_CONNECT_URL = GlobalSetting.Instance.MobileGetEndpoint.ToString();
        private readonly string SET_CONNECT_URL = GlobalSetting.Instance.MobileSetEndpoint.ToString();
        private readonly string CONNECT_URL_AUTH = GlobalSetting.Instance.MobileAuthEndpoint.ToString();
        private readonly string CONNECT_URL_VERIFY_TOKEN = GlobalSetting.Instance.MobileVerifyTokenEndpoint.ToString();
        private readonly string CONNECT_URL_WAREHOUSE = GlobalSetting.Instance.MobileGetWarehouseEndpoint.ToString();

        private string CONNECT_URL = string.Empty;

        public static BaseHttpService Instance
        {
            get
            {
                return instance;
            }
        }

        public async Task<string> SendRequestAsync(HttpCommand httpCommand, object requestData = null)
        {
            string result = string.Empty;

            // Default to GET
            //var method = httpMethod ?? HttpMethod.Get;
            if (httpCommand.Equals(HttpCommand.GET))
            {
                CONNECT_URL = GET_CONNECT_URL;
            }
            else
            {
                CONNECT_URL = SET_CONNECT_URL;
            }

            if (string.IsNullOrEmpty(GlobalSetting.Instance.AuthToken))
            {
                return "토큰이 없습니다. 다시 로그인 해주세요.";
            }


            // Serialize request data
            var data = requestData == null
                ? null
                : JsonConvert.SerializeObject(requestData);



            try
            {
                using (var request = new HttpRequestMessage(HttpMethod.Post, new Uri(CONNECT_URL)))
                {
                    if (data != null)
                    {
                        request.Headers.Add("jwt", GlobalSetting.Instance.AuthToken);
                        request.Content = new StringContent(data, Encoding.UTF8, "application/json");
                    }

                    // Add headers to request
                    //if (headers != null)
                    //{
                    //    foreach (var h in headers)
                    //    {
                    //        request.Headers.Add(h.Key, h.Value);
                    //    }
                    //}

                    using (var handler = new HttpClientHandler())
                    {
                        using (var client = new HttpClient(handler))
                        {
                            Console.WriteLine(client.Timeout.ToString());
                            //client.Timeout = new TimeSpan(0, 3, 0); //3분
                            //using (var response = await client.SendAsync(request, HttpCompletionOption.ResponseContentRead).ConfigureAwait(false))
                            using (var response = await client.SendAsync(request))
                            {
                                var content = response.Content == null
                                    ? null
                                    : await response.Content.ReadAsStringAsync();

                                if (response.IsSuccessStatusCode)
                                {
                                    //result = JsonConvert.DeserializeObject<T>(content);
                                    result = content;
                                }
                            }

                            return result;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //var properties = new Dictionary<string, string>
                //{
                //    {"BaseHttpService", "SendRequestAsync" },
                //    {"UserID", Settings.Userid}
                //};
                //Crashes.TrackError(ex, properties);

                return "ERROR " + ex.Message.ToString();
            }
        }

        public async Task<string> AuthorizationAsync(string jsonString)
        {
            HttpResponseMessage response = null;
            try
            {
                using (var client = new HttpClient())
                {
                    //client.BaseAddress = new Uri(CONNECT_URL_AUTH.ToString());
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    //client.Timeout = new TimeSpan(0, 3, 0); //3분

                    using (var request = new HttpRequestMessage(HttpMethod.Post, new Uri(CONNECT_URL_AUTH.ToString())))
                    {
                        request.Headers.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(jsonString)));
                        response = await client.SendAsync(request);
                    }

                    if (response.IsSuccessStatusCode)
                    {
                        return await response.Content.ReadAsStringAsync();
                    }
                    else
                    {
                        return string.Empty;
                    }
                }
            }
            catch (Exception ex)
            {
                return "ERROR " + ex.Message.ToString();
            }
            finally
            {
                if (response != null) response.Dispose();
            }
        }

        public async Task<string> GetWarehouse(string jsonString)
        {
            HttpResponseMessage response = null;
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(CONNECT_URL_WAREHOUSE.ToString());
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    //client.Timeout = new TimeSpan(0, 3, 0); //3분

                    using (var request = new HttpRequestMessage())
                    {
                        request.Method = HttpMethod.Post;

                        request.Headers.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(jsonString)));

                        response = await client.SendAsync(request);
                    }

                    if (response.IsSuccessStatusCode)
                    {
                        return await response.Content.ReadAsStringAsync();
                    }
                    else
                    {
                        return string.Empty;
                    }
                }
            }
            catch (Exception ex)
            {
                return "ERROR " + ex.Message.ToString();
            }
            finally
            {
                if (response != null) response.Dispose();
            }
        }

        public async Task<bool> VerifyToken()
        {
            bool result = false;

            try
            {
                if (string.IsNullOrEmpty(GlobalSetting.Instance.AuthToken))
                {
                    return false;
                }

                using (var request = new HttpRequestMessage(HttpMethod.Post, new Uri(CONNECT_URL_VERIFY_TOKEN)))
                {
                    request.Headers.Add("jwt", GlobalSetting.Instance.AuthToken);

                    using (var handler = new HttpClientHandler())
                    {
                        using (var client = new HttpClient(handler))
                        {
                            Console.WriteLine(client.Timeout.ToString());
                            //client.Timeout = new TimeSpan(0, 3, 0); //3분
                            //using (var response = await client.SendAsync(request, HttpCompletionOption.ResponseContentRead).ConfigureAwait(false))
                            using (var response = await client.SendAsync(request))
                            {
                                var content = response.Content == null
                                    ? null
                                    : await response.Content.ReadAsStringAsync();

                                if (response.IsSuccessStatusCode)
                                {
                                    //result = JsonConvert.DeserializeObject<T>(content);
                                    if (content != null)
                                    {
                                        if (content.Equals("OK"))
                                        {
                                            result = true;
                                        }
                                        else
                                        {
                                            result = false;
                                            GlobalSetting.Instance.AuthToken = string.Empty;
                                            Microsoft.Win32.Registry.SetValue("HKEY_CURRENT_USER\\Software\\BarcodeInspection", "AuthToken", "");
                                        }
                                    }
                                }
                            }

                            return result;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
