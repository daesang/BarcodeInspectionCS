using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarcodeInspection.Models
{
    public class Lobsc020Model
    {

        public Lobsc020Model()
        {

        }

        [JsonProperty("slipno")] //전표번호
        public string Slipno { get; set; }


        [JsonProperty("compky")] //회사코드
        public string Compky { get; set; }

        [JsonProperty("wareky")] //물류센터
        public string Wareky { get; set; }

        [JsonProperty("rqshpd")] //납품요청일
        public DateTime Rqshpd { get; set; }

        [JsonProperty("dlwrky")]  //납품센터
        public string Dlwrky { get; set; }

        [JsonProperty("dlwrnm")]
        public string Dlwrnm { get; set; }

        [JsonProperty("ruteky")] //배차코드
        public string Ruteky { get; set; }

        [JsonProperty("rutenm")]
        public string Rutenm { get; set; }

        [JsonProperty("lbbrcd")] //라벨 바코드
        public string Lbbrcd { get; set; }

        [JsonProperty("dlvycd")] //매출처
        public string Dlvycd { get; set; }

        [JsonProperty("dlvynm")]
        public string Dlvynm { get; set; }

        [JsonProperty("prodcd")] //상품코드
        public string Prodcd { get; set; }

        [JsonProperty("prodnm")] //상품명
        public string Prodnm { get; set; }

        [JsonProperty("ordqty")] //주문수량
        public Decimal Ordqty { get; set; }

        [JsonProperty("pickingtime")] //피킹 시간
        public string Pickingtime { get; set; }

        [JsonProperty("pickinguser")] //피킹 작업자
        public string Pickinguser { get; set; }

        [JsonProperty("shiptime")] //출차 시간
        public string Shiptime { get; set; }

        [JsonProperty("shipuser")] //출차 작업자
        public string Shipuser { get; set; }
    }
}
