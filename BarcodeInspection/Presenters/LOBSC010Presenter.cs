﻿using BarcodeInspection.Helper;
using BarcodeInspection.Models;
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
    public class LOBSC010Presenter : Presenter<ILOBSC010View>
    {
        public LOBSC010Presenter(ILOBSC010View view) : base(view)
        {

        }


        public DataTable ExcelUpload(DataTable dt, DateTime Rqshpd, string customer)
        {
            DataTable dtResult = new DataTable(); ;
            if(customer.Equals("1010") || customer.Equals("1011"))
            {
                dtResult = ExcelUpload1010(dt, customer);
            }
            else if (customer.Equals("1040"))
            {
                dtResult = ExcelUpload1040(dt, customer);
            }

            return dtResult;           
        }


        /// <summary>
        /// 1001.삼성웰스토리-평택/용인
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private DataTable ExcelUpload1010(DataTable dt, string customer)
        {
            var query =
                        from dr in dt.AsEnumerable()
                        select new
                        {
                            compky = "A001",
                            wareky = "10",
                            rqshpd = dr.Field<DateTime>(21).ToString("yyyy-MM-dd"),
                            dlwrky = customer,
                            dlwrnm = customer.Equals("1010")? "삼성웰스토리-평택": "삼성웰스토리-용인",
                            ruteky = dr.Field<string>(10),
                            rutenm = dr.Field<string>(10),
                            lbbrcd = dr.Field<string>(35),
                            dlvycd = dr.Field<string>(8),
                            dlvynm = dr.Field<string>(9),
                            prodcd = Convert.ToString(dr.Field<object>(4)).Substring(0, 10),
                            prodnm = dr.Field<string>(5),
                            ordqty = dr.Field<object>(17),
                            status = "N"
                        };
            return CustomLINQtoDataSetMethods.CopyToDataTable(query);
        }

        /// <summary>
        /// 1004.동원홈푸드
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private DataTable ExcelUpload1040(DataTable dt, string customer)
        {
            var query =
                        from dr in dt.AsEnumerable()
                        select new
                        {
                            //compky = "A001",
                            //wareky = "10",
                            //rqshpd = string.Format("{0}-{1}-{2}", dr.Field<string>(21).Substring(0, 4), dr.Field<string>(21).Substring(4, 2), dr.Field<string>(21).Substring(6, 2)),   //"20190321" 이런형태
                            //dlwrky = "1004",
                            //dlwrnm = "동원홈푸드",
                            //ruteky = dr.Field<string>(3) == "시화(FS)" ? "R10" : dr.Field<string>(3) == "시화(급식유통)" ? "R11" : " ",
                            //rutenm = dr.Field<string>(3),
                            //lbbrcd = dr.Field<string>(25).Substring(0, 31),
                            //dlvycd = dr.Field<string>(24), //납품처
                            //dlvynm = dr.Field<string>(4), //납품처명
                            //prodcd = Convert.ToString(dr.Field<double>(0)).Substring(0, 6), 
                            //prodnm = dr.Field<string>(1),
                            //ordqty = dr.Field<object>(6),
                            //status = "N"

                            compky = "A001",
                            wareky = "10",
                            rqshpd = string.Format("{0}-{1}-{2}", dr.Field<string>(22).Substring(0, 4), dr.Field<string>(22).Substring(4, 2), dr.Field<string>(22).Substring(6, 2)),   //"20190321" 이런형태
                            dlwrky = customer,
                            dlwrnm = "동원홈푸드",
                            //ruteky = dr.Field<string>(4) == "시화(FS)" ? "R10" : dr.Field<string>(4) == "시화(급식유통)" ? "R11" : " ",
                            ruteky = dr.Field<string>(4).ToString().Trim(),
                            rutenm = dr.Field<string>(4).ToString().Trim(),
                            //lbbrcd = dr.Field<string>(26).Substring(0, 31),
                            lbbrcd = dr.Field<string>(26).ToString().Trim(),
                            //dlvycd = dr.Field<string>(25), //납품처
                            dlvycd = dr.Field<string>(5).ToString().Trim(), //납품처
                            dlvynm = dr.Field<string>(5).ToString().Trim(), //납품처명
                            //prodcd = Convert.ToString(dr.Field<double>(1)).Substring(0, 6),
                            prodcd = dr.Field<string>(1),
                            prodnm = dr.Field<string>(2),
                            ordqty = dr.Field<object>(7),
                            status = "N"
                        };
            return CustomLINQtoDataSetMethods.CopyToDataTable(query);
        }

        public async Task Save(DataGridView dgv, DateTime Rqshpd, string customer, bool isChecked)
        {
            string responseResult = string.Empty;

            if(dgv.DataSource == null || dgv.Rows.Count == 0)
            {
                return;
            }

            Debug.WriteLine(dgv.Rows[0].Cells["rqshpd"].Value.ToString());  
            
            if(!Rqshpd.ToString("yyyy-MM-dd").Equals(dgv.Rows[0].Cells["rqshpd"].Value.ToString()))
            {
                MessageBox.Show("납품 요청일을 확인해 주세요.\n화면과 엑셀의 납품 요청일이 다릅니다.");
                return;
            }            

            string jsonString = JsonConvert.SerializeObject((dgv.DataSource as DataTable));

            //List<Lobsps1Model> lst_param = new List<Lobsps1Model>();
            //for (int i = 0; i < 1; i++)
            //{
            //    lst_param.Add
            //    (
            //        new Lobsps1Model
            //        {
            //            Compky = dt.Rows[i]["compky"].ToString(),
            //            Wareky = dt.Rows[i]["wareky"].ToString(),
            //            Rqshpd = Convert.ToDateTime(dt.Rows[i]["rqshpd"].ToString()),
            //            Dlwrky = dt.Rows[i]["dlwrky"].ToString(),
            //            Dlwrnm = dt.Rows[i]["dlwrnm"].ToString(),
            //            Ruteky = dt.Rows[i]["ruteky"].ToString(),
            //            Rutenm = dt.Rows[i]["rutenm"].ToString(),
            //            Lbbrcd = dt.Rows[i]["lbbrcd"].ToString(),
            //            Dlvycd = dt.Rows[i]["dlvycd"].ToString(),
            //            Dlvynm = dt.Rows[i]["dlvynm"].ToString(),
            //            Prodcd = dt.Rows[i]["prodcd"].ToString(),
            //            Prodnm = dt.Rows[i]["prodnm"].ToString(),
            //            Ordqty = Convert.ToDecimal(dt.Rows[i]["ordqty"].ToString())
            //        }
            //    );
            //}

            //string jsonString = JsonConvert.SerializeObject(lst_param);

            Dictionary<string, string> requestDic = new Dictionary<string, string>();
            requestDic.Add("UFN", "{? = call ufn_set_lobsc010(?, ?)}");  //함수 호출
            requestDic.Add("p_barcode_json", jsonString);
            requestDic.Add("p_userid", "90773532");

            responseResult = await BaseHttpService.Instance.SendRequestAsync(HttpCommand.SET, requestDic);

            if (!responseResult.Equals("OK"))
            {
                MessageBox.Show(responseResult);
            }
            else
            {
                await Search(dgv, Rqshpd, customer, isChecked);
            }
        }

        public async Task Search(DataGridView dgv, DateTime Rqshpd, string customer, bool isChecked)
        {
            string responseResult = string.Empty;

            Clear(dgv);

            Dictionary<string, string> requestDic = new Dictionary<string, string>();
            requestDic.Add("UFN", "{? = call ufn_get_lobsc010(?, ?, ?, ?, ?)}");  //함수 호출
            requestDic.Add("p_compky", "A001");     
            requestDic.Add("p_wareky", "10");
            requestDic.Add("p_rqshpd", Rqshpd.ToString("yyyy-MM-dd"));
            requestDic.Add("p_dlwrky", customer);
            requestDic.Add("p_status", isChecked?"Y":"N");


            responseResult = await BaseHttpService.Instance.SendRequestAsync(HttpCommand.GET, requestDic);

            if(!string.IsNullOrEmpty(responseResult))
            {
                //List<Lobsps1Model> _lstLobsps1Model = new List<Lobsps1Model>();
                //_lstLobsps1Model = JsonConvert.DeserializeObject<List<Lobsps1Model>>(responseResult);

                DataTable dt = (DataTable)JsonConvert.DeserializeObject(responseResult, (typeof(DataTable)));
                Debug.WriteLine(dt.Rows.Count);

                dgv.DataSource = dt;
            }
        }

        public void Clear(DataGridView dgv)
        {
            if(dgv.DataSource == null || dgv.Rows.Count == 0)
            {
                return;
            }

            int row = dgv.Rows.Count;

            for (int i = 0; i < row; i++)
            {
                dgv.Rows.RemoveAt(0);
            }
        }

        public async Task Confirm(DataGridView dgv, DateTime Rqshpd, string customer)
        {
            string responseResult = string.Empty;

            Dictionary<string, string> requestDic = new Dictionary<string, string>();
            requestDic.Add("UFN", "{? = call ufn_set_lobsc011(?, ?, ?, ?, ?)}");  //함수 호출
            requestDic.Add("p_rqshpd", Rqshpd.ToString("yyyy-MM-dd"));
            requestDic.Add("p_compky", "A001");
            requestDic.Add("p_wareky", "10");
            requestDic.Add("p_dlwrky", customer);
            requestDic.Add("p_userid", "90773532");

            responseResult = await BaseHttpService.Instance.SendRequestAsync(HttpCommand.SET, requestDic);

            if (!responseResult.Equals("OK"))
            {
                MessageBox.Show(responseResult);
            }
            else
            {
                await Search(dgv, Rqshpd, customer, false);
            }
        }
    }
}
