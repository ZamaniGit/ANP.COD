using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ANP.Data.BaseData.Report
{
    [Serializable()]
    public class ReportObject
    {
        public string StateCode { get; set; }
        public string CityCode { get; set; }
        public string PostNodeCode { get; set; }
        public string LastStateCode { get; set; }
        public string LastCityCode { get; set; }
        public string LastPostNode { get; set; }
        public string UserID { get; set; }
        public string FirstDate { get; set; }
        public string LastDate { get; set; }
        public string BarcodeStatusID { get; set; }
        public string ReceiptSeriAlepha { get; set; }
        public string ReceiptNo { get; set; }
        public string ReceiptSeriNo { get; set; }
        public string ReceiptTypeValue { get; set; }
        public string FinancialMoodValue { get; set; }
        public string ApproveFlag { get; set; }
        public string PayType { get; set; }
        public string BarCode { get; set; }
        public string Credit { get; set; }

        public ReportObject(string Param)
        {
            if (Param != string.Empty)
            {
                ClearOldData();
                string[] para = Param.Split('#');
                foreach (string s in para)
                {
                    string[] item = s.Split('|');
                    switch (item[0])
                    {
                        case "StateCode": StateCode = item[1]; break;
                        case "CityCode": CityCode = item[1]; break;
                        case "PostNodeCode": PostNodeCode = item[1]; break;
                        case "LastStateCode": LastStateCode = item[1]; break;
                        case "LastCityCode": LastCityCode = item[1]; break;
                        case "LastPostNode": LastPostNode = item[1]; break;
                        case "UserID": UserID = item[1]; break;
                        case "FirstDate": FirstDate = item[1]; break;
                        case "LastDate": LastDate = item[1]; break;
                        case "BarcodeStatusID": BarcodeStatusID = item[1]; break;
                        case "ReceiptSeriAlepha": ReceiptSeriAlepha = item[1]; break;
                        case "ReceiptNo": ReceiptNo = item[1]; break;
                        case "ReceiptSeriNo": ReceiptSeriNo = item[1]; break;
                        case "ReceiptType": ReceiptTypeValue = item[1]; break;
                        case "FinancialMoodValue": FinancialMoodValue = item[1]; break;
                        case "ApproveFlag": ApproveFlag = item[1]; break;
                        case "PayType": PayType = item[1]; break;
                        case "BarCode": BarCode = item[1]; break;
                        case "Credit": Credit = item[1]; break;
                    }
                }
            }
        }

        private void ClearOldData()
        {
            StateCode =
            CityCode =
            PostNodeCode =
            LastStateCode =
            LastCityCode =
            LastPostNode =
            UserID =
            FirstDate =
            LastDate =
            BarcodeStatusID =
            ReceiptSeriAlepha =
            ReceiptNo =
            ReceiptSeriNo =
            ReceiptTypeValue =
            FinancialMoodValue =
            ApproveFlag =
            PayType =
            BarCode =
            Credit = string.Empty;
        }
    }
}