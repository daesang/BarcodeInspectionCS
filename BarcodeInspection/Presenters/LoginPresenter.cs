﻿using BarcodeInspection.Models;
using BarcodeInspection.Services;
using BarcodeInspection.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarcodeInspection.Presenters
{
    public class LoginPresenter : Presenter<ILoginView>
    {
        public LoginPresenter(ILoginView view) : base(view)
        {
            //View.Compky = "A001";
        }

        public async void Login()
        {
            Console.WriteLine(View.Compky);
            Console.WriteLine(View.Wareky);
            Console.WriteLine(View.Userid);
            Console.WriteLine(View.Passwd);

            var p = new LoginUserModel { Compky = View.Compky, Wareky = View.Wareky, Userid = View.Userid, Passwd = View.Passwd };
            string jsonString = JsonConvert.SerializeObject(p);

            string result = await BaseHttpService.Instance.AuthorizationAsync(jsonString);

            if (string.IsNullOrEmpty(result) || result.StartsWith("ERROR"))
            {
                return;
            }
            else
            {
                LoginUserModel loginUser = JsonConvert.DeserializeObject<LoginUserModel>(result);
                System.Diagnostics.Debug.WriteLine(loginUser.AuthToken);

                Microsoft.Win32.Registry.SetValue("HKEY_CURRENT_USER\\Software\\BarcodeInspection", "Compky", View.Compky);
                Microsoft.Win32.Registry.SetValue("HKEY_CURRENT_USER\\Software\\BarcodeInspection", "Wareky", View.Wareky);
                Microsoft.Win32.Registry.SetValue("HKEY_CURRENT_USER\\Software\\BarcodeInspection", "Userid", View.Userid);
                Microsoft.Win32.Registry.SetValue("HKEY_CURRENT_USER\\Software\\BarcodeInspection", "AuthToken", loginUser.AuthToken);

                GlobalSetting.Instance.AuthToken = loginUser.AuthToken;
            }
        }

        public async Task<List<WarehouseModel>> SearchWarehouse()
        {
            List<WarehouseModel> result = new List<WarehouseModel>();

            var p = new LoginUserModel { Compky = View.Compky };
            string jsonString = JsonConvert.SerializeObject(p);
            string responseResult = await BaseHttpService.Instance.GetWarehouse(jsonString);

            if (string.IsNullOrEmpty(responseResult) || responseResult.StartsWith("ERROR"))
            {
                if (responseResult.StartsWith("ERROR"))
                {

                }
            }
            else
            {
                result = new List<WarehouseModel>(JsonConvert.DeserializeObject<List<WarehouseModel>>(responseResult));
            }

             return result;
        }

    }
}
