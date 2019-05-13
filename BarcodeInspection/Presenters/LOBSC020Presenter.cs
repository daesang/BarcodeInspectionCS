using BarcodeInspection.Helper;
using BarcodeInspection.Services;
using BarcodeInspection.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BarcodeInspection.Presenters
{
    public class LOBSC020Presenter : Presenter<ILOBSC020View>
    {
        public LOBSC020Presenter(ILOBSC020View view) : base(view)
        {

        }

        public async Task Search()
        {
            string responseResult = string.Empty;

            Clear();

            Dictionary<string, string> requestDic = new Dictionary<string, string>
            {
                { "UFN", "{? = call ufn_get_lobsc020(?, ?, ?, ?, ?)}" },  //함수 호출
                { "p_compky", "A001" },
                { "p_wareky", "10" },
                { "p_rqshpd", View.Rqshpd.ToString("yyyy-MM-dd") },
                { "p_dlwrky", View.Customer },
                { "p_wavecd", View.Wavecd },
            };

            responseResult = await BaseHttpService.Instance.SendRequestAsync(HttpCommand.GET, requestDic);

            if (!string.IsNullOrEmpty(responseResult))
            {
                //List<Lobsps1Model> _lstLobsps1Model = new List<Lobsps1Model>();
                //_lstLobsps1Model = JsonConvert.DeserializeObject<List<Lobsps1Model>>(responseResult);

                DataTable dt = (DataTable)JsonConvert.DeserializeObject(responseResult, (typeof(DataTable)));
                Debug.WriteLine(dt.Rows.Count);

                View.ExcelDataGridView.DataSource = dt;
            }
        }


        public void Clear()
        {
            if (View.ExcelDataGridView.DataSource == null || View.ExcelDataGridView.Rows.Count == 0)
            {
                return;
            }

            int row = View.ExcelDataGridView.Rows.Count;

            for (int i = 0; i < row; i++)
            {
                View.ExcelDataGridView.Rows.RemoveAt(0);
            }
        }
    }
}
